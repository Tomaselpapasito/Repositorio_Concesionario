using lib_dominio.entidades;
using lib_dominio.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace lib_dominio.implementaciones
{
    public class ClientesAplicacion : IClientesAplicacion
    {
        private IConexion IConexion;

        public ClientesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Clientes Actualizar(Clientes entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Clientes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Clientes Borrar(Clientes entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Clientes!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Clientes> Buscar(Clientes entidad)
        {
            return this.IConexion.Clientes!
                .Include (x=> x._Persona)
                .Where(x => x.Numero_Licencia!.Contains(entidad.Numero_Licencia!))
                .ToList();
        }

        public List<Clientes> Consultar()
        {
            return this.IConexion.Clientes!
                .Take(5).ToList();
        }

        public Clientes Insertar(Clientes entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Clientes!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Clientes entidad)
        {
            return string.IsNullOrEmpty(entidad.Numero_Licencia) ||
                string.IsNullOrEmpty(entidad.Direccion) ||
                entidad.Persona == 0;
         }
    }
}