using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorio.Implementaciones
{
    public class RepuestosAplicacion : IRepuestosAplicacion
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;
        public RepuestosAplicacion (IConexion IConexion, IAuditorias IAuditorias)
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;

        }

        public Repuestos Actualizar(Repuestos entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Repuestos>(entidad);
            entry.State = EntityState.Modified;
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasRepuestos>(
               objeto: 1,
               accion: "Actualizar",
               detalles: $"Numero {entidad.Numero_Parte} actualizado",
               usuario: IdUsuario
           );
            IConexion.AuditoriasRepuestos!.Add(auditoria);
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Repuestos Borrar(Repuestos entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Repuestos!.Remove(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasRepuestos>(
               objeto: 1,
               accion: "Borrar",
               detalles: $"Numero {entidad.Numero_Parte} borrado",
               usuario: IdUsuario
           );
            IConexion.AuditoriasRepuestos!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Repuestos> Buscar(Repuestos entidad)
        {
            return this.IConexion.Repuestos!
                .Include (x=> x._Producto)
                .Where(x => x.Numero_Parte!.Contains(entidad.Numero_Parte!))
                .ToList();
        }

        public List<Repuestos> Consultar()
        {
            return this.IConexion.Repuestos!
                .Take(5).ToList();
        }

        public Repuestos Insertar(Repuestos entidad, int IdUsuario)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Repuestos!.Add(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasRepuestos>(
               objeto: 1,
               accion: "Insertar",
               detalles: $"Numero {entidad.Numero_Parte} insertado",
               usuario: IdUsuario
           );
            IConexion.AuditoriasRepuestos!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}