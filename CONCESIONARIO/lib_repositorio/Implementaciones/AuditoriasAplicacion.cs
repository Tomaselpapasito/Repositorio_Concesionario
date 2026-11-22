using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorio.Implementaciones
{
    public class AuditoriasAplicacion : IAuditoriasNeogocio
    {
        private IConexion IConexion;

        public AuditoriasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Auditorias Actualizar(Auditorias entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Auditorias>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Auditorias Borrar(Auditorias entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Auditorias!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Auditorias> Buscar(Auditorias entidad)
        {
            return this.IConexion.Auditorias!
                .Where(x => x.Descripcion!.Contains(entidad.Descripcion!))
                .ToList();
        }

        public List<Auditorias> Consultar()
        {
            return this.IConexion.Auditorias!
                .Take(5).ToList();
        }

        public Auditorias Insertar(Auditorias entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Auditorias!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Auditorias entidad)
        {
            return string.IsNullOrEmpty(entidad.Descripcion);
         }
    }
}