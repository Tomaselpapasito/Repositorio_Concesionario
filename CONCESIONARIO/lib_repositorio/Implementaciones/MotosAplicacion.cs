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
            ValidarUnicosActualizar(entidad);
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
            validarUnicos(entidad);
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
        private void validarUnicos(Motos entidad)
        {
            var existe = this.IConexion.Motos!
                .Where(x => x.Numero_Motor == entidad.Numero_Motor)
                .FirstOrDefault();
            if (existe != null)
                throw new Exception("Ya existe un registro con el mismo numero de motor");
            if (!IConexion.ModelosMotos!.Any(x => x.ID == entidad.Modelo))
                throw new Exception("El modelo no existe");

        }
        private void ValidarUnicosActualizar(Motos entidad)
        {
            var existe = this.IConexion.Motos!
              .Where(x => x.Numero_Motor == entidad.Numero_Motor && x.ID != entidad.ID)
              .FirstOrDefault();
            if (existe != null)
                throw new Exception("Ya existe un registro con el mismo numero de motor");
            if (!IConexion.ModelosMotos!.Any(x => x.ID == entidad.Modelo))
                throw new Exception("El modelo no existe");
        }

    }
}