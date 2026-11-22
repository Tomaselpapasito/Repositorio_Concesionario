using lib_dominio.Entidades;
using lib_dominio.Interfaces;


namespace lib_presentaciones.Implementaciones
{
    public class MotosPresentacion : IMotosNegocio
    {
        private IComunicaciones IComunicaciones;

        public MotosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Motos Actualizar(Motos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Motos>(
                "Motos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Motos Borrar(Motos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Motos>(
                "Motos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Motos> Buscar(Motos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Motos>>(
                "Motos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Motos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Motos>>(
                "Motos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Motos Insertar(Motos entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Motos>(
                "Motos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        
    }
}