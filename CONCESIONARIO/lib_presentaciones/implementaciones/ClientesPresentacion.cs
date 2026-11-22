using lib_dominio.entidades;
using lib_dominio.interfaces;
using lib_presentaciones.interfaces;

namespace lib_presentaciones.implementaciones
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

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Clientes>(
                "Clientes/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Clientes Borrar(Clientes entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Clientes>(
                "Clientes/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Clientes> Buscar(Clientes entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Clientes>>(
                "Clientes/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Clientes> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Clientes>>(
                "Clientes/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Clientes Insertar(Clientes entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Clientes>(
                "Clientes/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Clientes entidad)
        {
            return string.IsNullOrEmpty(entidad.Numero_Licencia) ||
                string.IsNullOrEmpty(entidad.Correo) ||
                string.IsNullOrEmpty(entidad.Direccion) ||
                entidad.Persona == 0;
               
        }
    }
}