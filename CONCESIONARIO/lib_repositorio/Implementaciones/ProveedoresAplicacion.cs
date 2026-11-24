using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorio.Implementaciones
{
    public class ProveedoresAplicacion : IProveedoresAplicacion
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;
        public ProveedoresAplicacion (IConexion IConexion, IAuditorias IAuditorias)
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;

        }

        public Proveedores Actualizar(Proveedores entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Proveedores>(entidad);
            entry.State = EntityState.Modified;
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasProveedores>(
                objeto: 1,
                accion: "Actualizar",
                detalles: $"NIT {entidad.NIT} actualizado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasProveedores!.Add(auditoria);
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Proveedores Borrar(Proveedores entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Proveedores!.Remove(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasProveedores>(
                objeto: 1,
                accion: "Borrar",
                detalles: $"NIT {entidad.NIT} borrado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasProveedores!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Proveedores> Buscar(Proveedores entidad)
        {
            return this.IConexion.Proveedores!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public Proveedores BuscarPorNIT(Proveedores entidad)
        {
            throw new NotImplementedException();
        }

        public List<Proveedores> BuscarPorNombre(Proveedores entidad)
        {
            throw new NotImplementedException();
        }

        public List<Proveedores> Consultar()
        {
            return this.IConexion.Proveedores!
                .Take(5).ToList();
        }

        public List<Compras> ConsultarCompras(Proveedores entidad)
        {
            throw new NotImplementedException();
        }

        public List<Proveedores> ConsultarProveedoresActivos()
        {
            throw new NotImplementedException();
        }

        public Proveedores Insertar(Proveedores entidad, int IdUsuario)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Proveedores!.Add(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasProveedores>(
                objeto: 1,
                accion: "Insertar",
                detalles: $"NIT {entidad.NIT} insertado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasProveedores!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}