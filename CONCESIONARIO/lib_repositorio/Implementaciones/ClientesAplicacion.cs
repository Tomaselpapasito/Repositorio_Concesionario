using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace lib_repositorio.Implementaciones
{
    public class ClientesAplicacion : IClientesAplicacion
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;
        public ClientesAplicacion(IConexion IConexion, IAuditorias IAuditorias)
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;

        }

        public Clientes Actualizar(Clientes entidad , int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");
            ValidarUnicos(entidad);
            if (!IConexion.Personas.Any(x => x.ID == entidad.ID))
                throw new Exception("Persona no existe");
            var entry = this.IConexion!.Entry<Clientes>(entidad);
            entry.State = EntityState.Modified;
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasClientes>(
                objeto: 1,
                accion: "Actualizar",
                detalles: $"Cliente {entidad.Numero_Licencia} actualizado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasClientes!.Add(auditoria);
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Clientes Borrar(Clientes entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Clientes!.Remove(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasClientes>(
                objeto: 1,
                accion: "Borrar",
                detalles: $"Cliente {entidad.Numero_Licencia} borrado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasClientes!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Clientes Buscar(Clientes entidad)
        {
            return this.IConexion.Clientes!
                .Include(x => x._Persona)
                .FirstOrDefault(x => x.Numero_Licencia!.Contains(entidad.Numero_Licencia!));
                
        }

        public Clientes BuscarPorVenta(int IdVenta) /// compras del cleinte
        {
            var venta = this.IConexion.Ventas.Include(x=> x._Cliente).FirstOrDefault(x => x.ID == IdVenta);
            if (venta == null)
                throw new Exception("La venta no exite");
            return Buscar(venta._Cliente);

        }

        public List<Clientes> Consultar()
        {
            return this.IConexion.Clientes!
                .Take(5).ToList();
        }

        public Clientes Insertar(Clientes entidad, int IdUsuario)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");
            ValidarUnicos(entidad);
            ValidarPersona(entidad);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasClientes>(
                objeto: 1,
                accion: "Insertar",
                detalles: $"Cliente {entidad.Numero_Licencia} insertado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasClientes!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }
        private void ValidarUnicos(Clientes entidad)
        {
            if(IConexion.Clientes!.Any(x => x.Numero_Licencia == entidad.Numero_Licencia))
                throw new Exception("El numero de licencia del cliente ya existe");
            if(IConexion.Clientes!.Any(x => x.Correo == entidad.Correo))
                throw new Exception("El correo del cliente ya existe");
        }
        private void ValidarPersona(Clientes entidad)
        {
            if (!IConexion.Personas.Any(x => x.ID == entidad.ID))
                throw new Exception("La persona no existe");
            if (IConexion.Clientes.Include(x => x._Persona).Any(x => x._Persona.ID == entidad.ID))
                throw new Exception("La persona ya esta asociada a otro cliente");
        }

    }
}