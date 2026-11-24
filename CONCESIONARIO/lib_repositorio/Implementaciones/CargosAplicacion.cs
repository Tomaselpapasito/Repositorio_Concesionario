using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace lib_repositorio.Implementaciones
{
    public class CargosAplicacion : ICargosAplicacion
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;
        public CargosAplicacion(IConexion IConexion, IAuditorias IAuditorias)    
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;

        }

        public Cargos Actualizar(Cargos entidad , int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Cargos>(entidad);
            entry.State = EntityState.Modified;
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasCargos>(
                objeto: 1,
                accion: "Actualizar",
                detalles: $"Accesorio {entidad.Nombre} actualizado",
                usuario: IdUsuario
            );

            IConexion.AuditoriasCargos!.Add(auditoria);
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Cargos Borrar(Cargos entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Cargos!.Remove(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasCargos>(
                objeto: 1,
                accion: "Borrar",
                detalles: $"Accesorio {entidad.Nombre} borrado",
                usuario: IdUsuario
            );

            IConexion.AuditoriasCargos!.Add(auditoria);
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

        public Cargos Insertar(Cargos entidad, int IdUsuario)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Cargos!.Add(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasCargos>(
                objeto: 1,
                accion: "Insertar",
                detalles: $"Accesorio {entidad.Nombre} insertado",
                usuario: IdUsuario
            );

            IConexion.AuditoriasCargos!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }


    }
}