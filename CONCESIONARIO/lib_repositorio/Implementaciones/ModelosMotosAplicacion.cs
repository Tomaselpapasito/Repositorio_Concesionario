using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorio.Implementaciones
{
    public class ModelosMotosAplicacion : IModelosMotosAplicacion
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;
        public ModelosMotosAplicacion (IConexion IConexion, IAuditorias IAuditorias)
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;

        }

        public ModelosMotos Actualizar(ModelosMotos entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<ModelosMotos>(entidad);
            entry.State = EntityState.Modified;
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasModelosMotos>(
                objeto: 1,
                accion: "Actualizar",
                detalles: $"Nombre {entidad.Nombre} actualizado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasModelosMotos!.Add(auditoria);
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public ModelosMotos Borrar(ModelosMotos entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.ModelosMotos!.Remove(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasModelosMotos>(
                objeto: 1,
                accion: "Borrar",
                detalles: $"Nombre {entidad.Nombre} borrado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasModelosMotos!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<ModelosMotos> Buscar(ModelosMotos entidad)
        {
            return this.IConexion.ModelosMotos!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<ModelosMotos> Consultar()
        {
            return this.IConexion.ModelosMotos!
                .Take(5).ToList();
        }

        public ModelosMotos Insertar(ModelosMotos entidad, int IdUsuario)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.ModelosMotos!.Add(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasModelosMotos>(
                objeto: 1,
                accion: "Insertar",
                detalles: $"Nombre {entidad.Nombre} insertado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasModelosMotos!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}