using lib_dominio.entidades;
using lib_dominio.interfaces;
using lib_presentaciones.interfaces;

namespace lib_presentaciones.implementaciones
{
    public class DetallesVentasMotosPresentacion : IDetallesVentasMotosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public DetallesVentasMotosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public DetallesVentasMotos Actualizar(DetallesVentasMotos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<DetallesVentasMotos>(
                "DetallesVentasMotos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public DetallesVentasMotos Borrar(DetallesVentasMotos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<DetallesVentasMotos>(
                "DetallesVentasMotos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<DetallesVentasMotos> Buscar(DetallesVentasMotos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<DetallesVentasMotos>>(
                "DetallesVentasMotos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<DetallesVentasMotos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<DetallesVentasMotos>>(
                "DetallesVentasMotos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public DetallesVentasMotos Insertar(DetallesVentasMotos entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<DetallesVentasMotos>(
                "DetallesVentasMotos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(DetallesVentasMotos entidad)
        {
            return entidad.Moto == 0 ||
                entidad.Venta == 0;
        }
    }
}