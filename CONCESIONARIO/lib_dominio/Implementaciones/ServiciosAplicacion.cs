using lib_dominio.entidades;
using lib_dominio.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace lib_dominio.implementaciones
{
    public class ServiciosAplicacion : IServiciosAplicacion
    {
        private IConexion IConexion;

        public ServiciosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Servicios Actualizar(Servicios entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Servicios>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Servicios Borrar(Servicios entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Servicios!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Servicios> Buscar(Servicios entidad)
        {
            return this.IConexion.Servicios!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<Servicios> Consultar()
        {
            return this.IConexion.Servicios!
                .Take(5).ToList();
        }

        public Servicios Insertar(Servicios entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Servicios!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Servicios entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                entidad.Precio <= 0 ||
                entidad.Duracion <= 0 ||
                string.IsNullOrEmpty(entidad.Tipo_Servicio);
        }
    }
}