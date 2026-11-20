using lib_dominio.entidades;
using lib_dominio.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace lib_dominio.implementaciones
{
    public class OrdenesServiciosAplicacion : IOrdenesServiciosAplicacion
    {
        private IConexion IConexion;

        public OrdenesServiciosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public OrdenesServicios Actualizar(OrdenesServicios entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<OrdenesServicios>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public OrdenesServicios Borrar(OrdenesServicios entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.OrdenesServicios!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<OrdenesServicios> Buscar(OrdenesServicios entidad)
        {
            return this.IConexion.OrdenesServicios!
                .Include (x=> x._Empleado)
                .Include (x => x._Cliente)
                .Include (x=> x._Moto)
                .Where(x => x._Cliente!.Numero_Licencia!.Contains(entidad._Cliente!.Numero_Licencia!))
                .ToList();
        }

        public List<OrdenesServicios> Consultar()
        {
            return this.IConexion.OrdenesServicios!
                .Take(5).ToList();
        }

        public OrdenesServicios Insertar(OrdenesServicios entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.OrdenesServicios!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(OrdenesServicios entidad)
        {
            return 
                entidad.Costo_Total <= 0 ||
                string.IsNullOrEmpty(entidad.Descripcion) ||
                entidad.Cliente == 0    ||
                entidad.Empleado == 0   ||
                entidad.Moto == 0;
         }
    }
}