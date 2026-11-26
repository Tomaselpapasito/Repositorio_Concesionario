using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorio.Implementaciones
{
    public class ComprasAplicacion : IComprasAplicacion
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;
        public ComprasAplicacion(IConexion IConexion, IAuditorias IAuditorias)
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;

        }

        public Compras Actualizar(Compras entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");
            validarUnicosActualizar(entidad);
            var entry = this.IConexion!.Entry<Compras>(entidad);
            entry.State = EntityState.Modified;
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasCompras>(
                objeto: 1,
                accion: "Actualizar",
                detalles: $"Compra {entidad.Numero_Factura} actualizado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasCompras!.Add(auditoria);
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Compras Borrar(Compras entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Compras!.Remove(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasCompras>(
                objeto: 1,
                accion: "Borrar",
                detalles: $"Compra {entidad.Numero_Factura} borrado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasCompras!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Compras> Buscar(Compras entidad)
        {
            return this.IConexion.Compras!
                .Include(x => x._Proveedor)
                .Where(x => x.Numero_Factura!.Contains(entidad.Numero_Factura!))
                .ToList();
        }

        public List<Compras> Consultar()
        {
            return this.IConexion.Compras!
                .Take(5).ToList();
        }

        public Compras Insertar(Compras entidad, int IdUsuario)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");
            validarUnicos(entidad);
            entidad = CalcularTotal(entidad);
            this.IConexion.Compras!.Add(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasCompras>(
                objeto: 1,
                accion: "Insertar",
                detalles: $"Compra {entidad.Numero_Factura} insertado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasCompras!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private void validarUnicos(Compras entidad)
        {
            var existe = this.IConexion.Compras!
                .Where(x => x.Numero_Factura == entidad.Numero_Factura)
                .FirstOrDefault();
            if (existe != null)
                throw new Exception("Ya existe un registro con el mismo numero de factura");
            if (!IConexion.Proveedores!.Any(x => x.ID == entidad.Proveedor))
                throw new Exception("El proveedor no existe");

        }
        private void validarUnicosActualizar(Compras entidad)
        {
            var existe = this.IConexion.Compras!
                .Where(x => x.Numero_Factura == entidad.Numero_Factura && x.ID != entidad.ID)
                .FirstOrDefault();
            if (existe != null)
                throw new Exception("Ya existe un registro con el mismo numero de factura");
            if (!IConexion.Proveedores!.Any(x => x.ID == entidad.Proveedor))
                throw new Exception("El proveedor no existe");
        }
        private Compras CalcularTotal(Compras entidad)
        {
            entidad.DetallesCompras = IConexion.DetallesCompras!.Where(x => x.Compra == entidad.ID).ToList();
            foreach (var detalle in entidad.DetallesCompras)
                entidad.Total += detalle.Subtotal;
            return entidad;
        }
    }
}