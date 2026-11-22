using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_presentaciones.interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class FinanciamientosPresentacion : IFinanciamientosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public FinanciamientosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Financiamientos Actualizar(Financiamientos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Financiamientos>(
                "Financiamientos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Financiamientos Borrar(Financiamientos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Financiamientos>(
                "Financiamientos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Financiamientos> Buscar(Financiamientos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Financiamientos>>(
                "Financiamientos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Financiamientos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Financiamientos>>(
                "Financiamientos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Financiamientos Insertar(Financiamientos entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Financiamientos>(
                "Financiamientos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Financiamientos entidad)
        {
            return entidad.Monto <= 0 ||
                entidad.Numero_Cuotas <= 0 ||
                string.IsNullOrEmpty(entidad.Estado) ||
                entidad.Venta == 0;
        }
    }
}