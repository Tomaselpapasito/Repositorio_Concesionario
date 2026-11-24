using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorio.Implementaciones
{
    public class ProductosAplicacion : IProductosAplicacion
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;
        public ProductosAplicacion (IConexion IConexion, IAuditorias IAuditorias)
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;

        }

        public Productos Actualizar(Productos entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");
            if (ValidarCodigo(entidad))
                throw new Exception("Ya existe un producto con el mismo código");


            var entry = this.IConexion!.Entry<Productos>(entidad);
            entry.State = EntityState.Modified;
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasProductos>(
                objeto: 1,
                accion: "Actualizar",
                detalles: $"Codigo {entidad.Codigo} actualizado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasProductos!.Add(auditoria);
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Productos Borrar(Productos entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Productos!.Remove(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasProductos>(
                objeto: 1,
                accion: "Borrar",
                detalles: $"Codigo {entidad.Codigo} borrado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasProductos!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Productos> Buscar(Productos entidad)
        {
            return this.IConexion.Productos!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<Productos> Consultar()
        {
            return this.IConexion.Productos!
                .Take(5).ToList();
        }

        public Productos Insertar(Productos entidad, int IdUsuario)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");
            if (ValidarCodigo(entidad))
                throw new Exception("Ya existe un producto con el mismo código");
            
            this.IConexion.Productos!.Add(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasProductos>(
                objeto: 1,
                accion: "Insertar",
                detalles: $"Codigo {entidad.Codigo} insertado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasProductos!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool ValidarCodigo(Productos entidad)
        {
            return this.IConexion.Productos!.Any(x => x.Codigo == entidad.Codigo);
        }

        private bool BuscarPorId(int id)
        {
            return this.IConexion.Productos!.Any(x => x.ID == id);
        }

        public void ActualizarStock(int id, int cantidad)
        {
            var producto = this.IConexion.Productos!.FirstOrDefault(x => x.ID == id);
            if (!BuscarPorId(id))
                throw new Exception("Producto no encontrado");
            producto!.Stock += cantidad;
            this.IConexion.SaveChanges();

        }
    }
}