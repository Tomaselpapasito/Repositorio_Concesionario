using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class AccesoriosPresentacion : IAccesoriosNegocio
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

            if (entidad.Validar())
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

        public Accesorios BuscarPorProducto(int producto)
        {
            throw new NotImplementedException();
        }

        public List<Accesorios> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Accesorios>>(
                "Accesorios/Consultar",
                null!);
            task.Wait();
            return task.Result;
        }

        public List<Accesorios> ConsultarAccesoriosDisponibles()
        {
            throw new NotImplementedException();
        }

        public List<Accesorios> ConsultarAccesoriosPorPrecio(decimal precio)
        {
            throw new NotImplementedException();
        }

        public Accesorios Insertar(Accesorios entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Accesorios>(
                "Accesorios/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

    }
}