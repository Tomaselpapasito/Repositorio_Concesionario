using lib_dominio.entidades;
using lib_dominio.interfaces;
using lib_presentaciones.interfaces;

namespace lib_presentaciones.implementaciones
{
    public class DetallesVentasProductosPresentacion : IDetallesVentasProductosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public DetallesVentasProductosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public DetallesVentasProductos Actualizar(DetallesVentasProductos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<DetallesVentasProductos>(
                "DetallesVentasProductos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public DetallesVentasProductos Borrar(DetallesVentasProductos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<DetallesVentasProductos>(
                "DetallesVentasProductos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<DetallesVentasProductos> Buscar(DetallesVentasProductos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<DetallesVentasProductos>>(
                "DetallesVentasProductos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<DetallesVentasProductos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<DetallesVentasProductos>>(
                "DetallesVentasProductos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public DetallesVentasProductos Insertar(DetallesVentasProductos entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<DetallesVentasProductos>(
                "DetallesVentasProductos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(DetallesVentasProductos entidad)
        {
            return entidad.Cantidad <= 0 ||
                entidad.Producto == 0 ||
                entidad.Venta == 0;
        }
    }
}