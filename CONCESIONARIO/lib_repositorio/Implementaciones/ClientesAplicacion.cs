using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using lib_repositorio.Interfaces;


namespace lib_repositorio.Implementaciones
{
    public class ClientesAplicacion : IClientesNegocio
    {
        private IConexion IConexion;

        public ClientesAplicacion(IConexion IConexion )
        {
            this.IConexion = IConexion;
        }

        public Clientes Actualizar(Clientes entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Clientes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Clientes Borrar(Clientes entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Clientes!.Remove(entidad!);
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

        public Clientes Insertar(Clientes entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Clientes!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }


    }
}