using lib_dominio.Entidades;
using lib_dominio.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class DetallesVentasMotosPresentacion : IDetallesVentasMotosNegocio
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

            if (entidad.Validar())
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

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<DetallesVentasMotos>(
                "DetallesVentasMotos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

    }
}