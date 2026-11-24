using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace lib_repositorio.Implementaciones
{
    public class CargosAplicacion : ICargosAplicacion
    {
        private IConexion IConexion;

        public CargosAplicacion(IConexion IConexion)    
        {
            this.IConexion = IConexion;
        }

        public Cargos Actualizar(Cargos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Cargos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Cargos Borrar(Cargos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Cargos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Cargos> Buscar(Cargos entidad)
        {
            return this.IConexion.Cargos!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<Cargos> Consultar()
        {
            return this.IConexion.Cargos!
                .Take(5).ToList();
        }

        public Cargos Insertar(Cargos entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Cargos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }


    }
}