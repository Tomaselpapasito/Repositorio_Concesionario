using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class DetallesComprasPresentacion : IDetallesComprasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public DetallesComprasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public DetallesCompras Actualizar(DetallesCompras entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<DetallesCompras>(
                "DetallesCompras/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public DetallesCompras Borrar(DetallesCompras entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<DetallesCompras>(
                "DetallesCompras/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<DetallesCompras> Buscar(DetallesCompras entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<DetallesCompras>>(
                "DetallesCompras/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<DetallesCompras> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<DetallesCompras>>(
                "DetallesCompras/Consultar",
                null!);
            task.Wait();
            return task.Result;
        }

        public DetallesCompras Insertar(DetallesCompras entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<DetallesCompras>(
                "DetallesCompras/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

   
    }
}