using lib_dominio.entidades;
using lib_dominio.interfaces;
using lib_presentaciones.interfaces;

namespace lib_presentaciones.implementaciones
{
    public class AccesoriosPresentacion : IAccesoriosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public AccesoriosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Accesorios Actualizar(Accesorios entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Accesorios>(
                "Accesorios/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Accesorios Borrar(Accesorios entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Accesorios>(
                "Accesorios/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Accesorios> Buscar(Accesorios entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Accesorios>>(
                "Accesorios/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Accesorios> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Accesorios>>(
                "Accesorios/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Accesorios Insertar(Accesorios entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Accesorios>(
                "Accesorios/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Accesorios entidad)
        {
            return string.IsNullOrEmpty(entidad.Categoria) ||
                string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Marca);
        }
    }
}