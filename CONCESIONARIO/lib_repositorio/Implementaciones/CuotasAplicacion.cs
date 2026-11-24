using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_repositorio.Implementaciones
{
    public class CuotasAplicacion : ICuotasAplicacion
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;
        public CuotasAplicacion(IConexion IConexion, IAuditorias IAuditorias)
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;

        }

        public Cuotas Actualizar(Cuotas entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Cuotas>(entidad);
            entry.State = EntityState.Modified;
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasCuotas>(
                objeto: 1,
                accion: "Actualizar",
                detalles: $"Cuota {entidad.Numero_cuota} actualizado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasCuotas!.Add(auditoria);
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Cuotas Borrar(Cuotas entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Cuotas!.Remove(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasCuotas>(
                objeto: 1,
                accion: "Borrar",
                detalles: $"Cuota {entidad.Numero_cuota} borrado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasCuotas!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Cuotas> Buscar(Cuotas entidad)
        {
            return this.IConexion.Cuotas!
                .Include (x=> x._Financiamiento)
                    .ThenInclude (x => x!._Venta)
                        .ThenInclude(x => x!._Cliente)
                .ToList();
        }

        public List<Cuotas> Consultar()
        {
            return this.IConexion.Cuotas!
                .Take(5).ToList();
        }

        public Cuotas Insertar(Cuotas entidad, int IdUsuario)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Cuotas!.Add(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasCuotas>(
                objeto: 1,
                accion: "Insertar",
                detalles: $"Cuota {entidad.Numero_cuota} insertado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasCuotas!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }


    }
}