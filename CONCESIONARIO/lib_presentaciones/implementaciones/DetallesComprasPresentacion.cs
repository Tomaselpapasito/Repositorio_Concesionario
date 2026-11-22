using lib_dominio.entidades;
using lib_dominio.interfaces;
using lib_presentaciones.interfaces;

namespace lib_presentaciones.implementaciones
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

            if (Validar(entidad))
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
                null);
            task.Wait();
            return task.Result;
        }

        public DetallesCompras Insertar(DetallesCompras entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<DetallesCompras>(
                "DetallesCompras/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(DetallesCompras entidad)
        {
            return entidad.Cantidad <= 0 ||
                entidad.Compra == 0 ||
                entidad.Producto == 0;
        }
    }
}