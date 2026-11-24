using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorio.Implementaciones
{
    public class AccesoriosAplicacion : IAccesoriosAplicacion
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;

        public AccesoriosAplicacion(IConexion IConexion,IAuditorias IAuditorias)
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;
        }

        public Accesorios Actualizar(Accesorios entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            if(!IConexion.Productos!.Any(x => x.ID == entidad.Producto))
                throw new Exception("Producto no existe");

            var entry = this.IConexion!.Entry<Accesorios>(entidad);
            entry.State = EntityState.Modified;
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasAccesorios>(
                objeto: 1,
                accion: "Actualizar",
                detalles: $"Accesorio {entidad.Nombre} actualizado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasAccesorios!.Add(auditoria);
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Accesorios Borrar(Accesorios entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Accesorios!.Remove(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasAccesorios>(
                objeto: 1,
                accion: "Borrar",
                detalles: $"Accesorio {entidad.Nombre} borrado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasAccesorios!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Accesorios> Buscar(Accesorios entidad)
        {
            return this.IConexion.Accesorios!
                .Include (x=> x._Producto)
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public Accesorios BuscarPorProducto(int producto)
        {
            if (!this.IConexion.Productos!.Any(x => x.ID == producto))
                throw new Exception("Producto no existe");
            return this.IConexion.Accesorios!.Include(x => x._Producto).FirstOrDefault(x => x.Producto == x.Producto)!;
        }

        public List<Accesorios> Consultar()
        {
            return this.IConexion.Accesorios!
                .Take(5).ToList();
        }

        public List<Accesorios> ConsultarAccesoriosDisponibles()
        {
            return this.IConexion.Accesorios!.Include(x=> x._Producto)
                .Where(x => x._Producto!.Activo == true)
                .ToList();
        }

        public List<Accesorios> ConsultarAccesoriosPorPrecio(decimal precio)
        {
            return this.IConexion.Accesorios!.Include(x => x._Producto).Where(x => x._Producto!.Precio == precio).ToList();
        }

        public Accesorios Insertar(Accesorios entidad, int IdUsuario)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Accesorios!.Add(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasAccesorios>(
                objeto: 1,
                accion: "Insertar",
                detalles: $"Accesorio {entidad.Nombre} insertado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasAccesorios!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }


    }
}