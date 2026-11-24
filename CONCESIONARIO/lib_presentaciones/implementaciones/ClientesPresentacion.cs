
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class ClientesPresentacion : IClientesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ClientesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Clientes Actualizar(Clientes entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Clientes>(
                "Clientes/Actualizar", entidad);
            task.Wait();
            return task.Result;
        }

        public Clientes Borrar(Clientes entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Clientes>(
                "Clientes/Borrar", entidad);
            task.Wait();
            return task.Result;
        }

        public Clientes Buscar(Clientes entidad)
        {
            var task = this.IComunicaciones.Ejecutar<Clientes>(
                "Clientes/Buscar", entidad);
            task.Wait();
            return task.Result;
        }

        public Clientes BuscarPorVenta(int compra)
        {
            throw new NotImplementedException();
        }

        public List<Clientes> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Clientes>>(
                "Clientes/Consultar", null!);
            task.Wait();
            return task.Result;
        }

        public Clientes Insertar(Clientes entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Clientes>(
                "Clientes/Insertar", entidad);
            task.Wait();
            return task.Result;
        }
    }
}
