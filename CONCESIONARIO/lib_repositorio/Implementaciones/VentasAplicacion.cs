using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorio.Implementaciones
{
    public class VentasAplicacion : IVentasAplicacion
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;
        public VentasAplicacion (IConexion IConexion, IAuditorias IAuditorias)
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;

        }

        public Ventas Actualizar(Ventas entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Ventas>(entidad);
            entry.State = EntityState.Modified;
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasVentas>(
               objeto: 1,
               accion: "Actualizar",
               detalles: $"Total {entidad.Total} actualizado",
               usuario: IdUsuario
           );
            IConexion.AuditoriasVentas!.Add(auditoria);
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Ventas Borrar(Ventas entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Ventas!.Remove(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasVentas>(
               objeto: 1,
               accion: "Borrar",
               detalles: $"Total {entidad.Total} borrado",
               usuario: IdUsuario
           );
            IConexion.AuditoriasVentas!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Ventas> Buscar(Ventas entidad)
        {
            return this.IConexion.Ventas!
                .Include(x => x._Empleado)
                .Include(x => x._Cliente)
                .ToList();
        }

        public List<Ventas> Consultar()
        {
            return this.IConexion.Ventas!
                .OrderByDescending(x => x.Fecha_Venta)
                .ToList();
        }

        public Ventas Insertar(Ventas entidad, int IdUsuario)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Ventas!.Add(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasVentas>(
               objeto: 1,
               accion: "Insertar",
               detalles: $"Total {entidad.Total} insertado",
               usuario: IdUsuario
           );
            IConexion.AuditoriasVentas!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}