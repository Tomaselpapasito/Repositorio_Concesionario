using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using lib_repositorio.Interfaces;
using lib_dominio.Auditorias;

namespace lib_repositorio.Implementaciones
{
    public class MotosAplicacion : IMotosAplicacion
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;


        public MotosAplicacion(IConexion IConexion, IAuditorias IAuditorias)
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;
        }

        public Motos Actualizar(Motos entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Motos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasMotos>(1, "Actualizar", $"Se actualizo el registro {entidad.ID}", IdUsuario);
            IConexion.AuditoriasMotos!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Motos Borrar(Motos entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Motos!.Remove(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasMotos>(1, "Borrar", $"Se borro el registro {entidad.ID}", IdUsuario);
            IConexion.AuditoriasMotos!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Motos Insertar(Motos entidad, int IdUsuario)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Motos!.Add(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasMotos>(1, "Insertar", $"Se inserto el registro {entidad.ID}", IdUsuario);
            IConexion.AuditoriasMotos!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Motos> Buscar(Motos entidad)
        {
            return this.IConexion.Motos!
                .Include (x=> x._Modelo)
                .Where(x => x.VIN!.Contains(entidad.VIN!))
                .Where(x => x.Estado!.Contains(entidad.Estado!))
                .ToList();
        }

        public List<Motos> Consultar()
        {
            return this.IConexion.Motos!
                .Take(5).ToList();
        }


    }
}