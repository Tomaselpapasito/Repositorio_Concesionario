using lib_dominio.Entidades;
using lib_dominio.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class DetallesVentasProductosPresentacion : IDetallesVentasProductosNegocio
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

            if (entidad.Validar())
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

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<DetallesVentasProductos>(
                "DetallesVentasProductos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

    }
}