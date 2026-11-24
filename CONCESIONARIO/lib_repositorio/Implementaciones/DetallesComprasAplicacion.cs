using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_repositorio.Implementaciones
{
    public class DetallesComprasAplicacion : IDetallesComprasAplicacion
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;
        public DetallesComprasAplicacion(IConexion IConexion, IAuditorias IAuditorias)
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;

        }
        public DetallesCompras Actualizar(DetallesCompras entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<DetallesCompras>(entidad);
            entry.State = EntityState.Modified;
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasDetallesCompras>(
                objeto: 1,
                accion: "Actualizar",
                detalles: $"Cantidad {entidad.Cantidad} actualizado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasDetallesCompras!.Add(auditoria);
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public DetallesCompras Borrar(DetallesCompras entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.DetallesCompras!.Remove(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasDetallesCompras>(
                objeto: 1,
                accion: "Borrar",
                detalles: $"Cantidad {entidad.Cantidad} borrado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasDetallesCompras!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<DetallesCompras> Buscar(DetallesCompras entidad)
        {
            return this.IConexion.DetallesCompras!
                .Include(x => x._Compra)
                .Include(x => x._Producto)
                .ToList();
        }

        public List<DetallesCompras> Consultar()
        {
            return this.IConexion.DetallesCompras!
                .Take(5).ToList();
        }

        public DetallesCompras Insertar(DetallesCompras entidad, int IdUsuario)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.DetallesCompras!.Add(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasDetallesCompras>(
                objeto: 1,
                accion: "Insertar",
                detalles: $"Cantidad {entidad.Cantidad} insertado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasDetallesCompras!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }


    }
}