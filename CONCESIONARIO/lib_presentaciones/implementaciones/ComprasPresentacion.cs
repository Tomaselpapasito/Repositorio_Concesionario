using lib_dominio.Entidades;
using lib_dominio.Interfaces;


namespace lib_presentaciones.Implementaciones
{
    public class ComprasPresentacion : IComprasNegocio
    {
        private IComunicaciones IComunicaciones;

        public ComprasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Compras Actualizar(Compras entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Compras>(
                "Compras/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Compras Borrar(Compras entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Compras>(
                "Compras/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Compras> Buscar(Compras entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Compras>>(
                "Compras/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Compras> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Compras>>(
                "Compras/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Compras Insertar(Compras entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Compras>(
                "Compras/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Compras entidad)
        {
            return string.IsNullOrEmpty(entidad.Numero_Factura) ||
                entidad.Proveedor == 0;
        }
    }
}