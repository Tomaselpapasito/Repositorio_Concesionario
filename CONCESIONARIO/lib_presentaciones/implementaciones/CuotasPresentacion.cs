using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class CuotasPresentacion : ICuotasNegocio
    {
        private IComunicaciones IComunicaciones;

        public CuotasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Cuotas Actualizar(Cuotas entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Cuotas>(
                "Cuotas/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Cuotas Borrar(Cuotas entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Cuotas>(
                "Cuotas/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Cuotas> Buscar(Cuotas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Cuotas>>(
                "Cuotas/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Cuotas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Cuotas>>(
                "Cuotas/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Cuotas Insertar(Cuotas entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Cuotas>(
                "Cuotas/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

     
    }
}