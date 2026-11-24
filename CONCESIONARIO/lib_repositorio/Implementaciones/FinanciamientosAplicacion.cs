using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorio.Implementaciones
{
    public class FinanciamientosAplicacion : IFinanciamientosAplicacion
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;
        public FinanciamientosAplicacion (IConexion IConexion, IAuditorias IAuditorias)
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;

        }

        public Financiamientos Actualizar(Financiamientos entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Financiamientos>(entidad);
            entry.State = EntityState.Modified;
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasFinanciamientos>(
                objeto: 1,
                accion: "Actualizar",
                detalles: $"Cuota {entidad.Cuotas} actualizado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasFinanciamientos!.Add(auditoria);
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Financiamientos Borrar(Financiamientos entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Financiamientos!.Remove(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasFinanciamientos>(
                objeto: 1,
                accion: "Borrar",
                detalles: $"Cuota {entidad.Cuotas} borrado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasFinanciamientos!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Financiamientos> Buscar(Financiamientos entidad)
        {
            return this.IConexion.Financiamientos!
                .Include (x=> x._Venta)
                    .ThenInclude (x => x!._Cliente)
                .ToList();
        }

        public List<Financiamientos> Consultar()
        {
            return this.IConexion.Financiamientos!
                .Take(5).ToList();
        }

        public Financiamientos Insertar(Financiamientos entidad, int IdUsuario)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Financiamientos!.Add(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasFinanciamientos>(
                objeto: 1,
                accion: "Insertar",
                detalles: $"Cuota {entidad.Cuotas} insertado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasFinanciamientos!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}