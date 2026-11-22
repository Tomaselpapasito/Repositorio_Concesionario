using lib_dominio.Entidades;
using lib_dominio.Interfaces;
 

namespace lib_presentaciones.Implementaciones
{
    public class PagosPresentacion : IPagosNegocio
    {
        private IComunicaciones IComunicaciones;

        public PagosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Pagos Actualizar(Pagos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Pagos>(
                "Pagos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Pagos Borrar(Pagos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Pagos>(
                "Pagos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Pagos> Buscar(Pagos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Pagos>>(
                "Pagos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Pagos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Pagos>>(
                "Pagos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Pagos Insertar(Pagos entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Pagos>(
                "Pagos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Pagos entidad)
        {
            return entidad.Monto <= 0 ||
                entidad.Metodo == 0 ||
                entidad.Venta == 0;
        }
    }
}