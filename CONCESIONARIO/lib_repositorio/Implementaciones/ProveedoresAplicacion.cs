using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using lib_repositorio.Interfaces;

namespace lib_repositorio.Implementaciones
{
    public class ProveedoresAplicacion : IProveedoresNegocio
    {
        private IConexion IConexion;

        public ProveedoresAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Proveedores Actualizar(Proveedores entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Proveedores>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Proveedores Borrar(Proveedores entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Proveedores!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Proveedores> Buscar(Proveedores entidad)
        {
            return this.IConexion.Proveedores!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public Proveedores BuscarPorNIT(Proveedores entidad)
        {
            throw new NotImplementedException();
        }

        public List<Proveedores> BuscarPorNombre(Proveedores entidad)
        {
            throw new NotImplementedException();
        }

        public List<Proveedores> Consultar()
        {
            return this.IConexion.Proveedores!
                .Take(5).ToList();
        }

        public List<Compras> ConsultarCompras(Proveedores entidad)
        {
            throw new NotImplementedException();
        }

        public List<Proveedores> ConsultarProveedoresActivos()
        {
            throw new NotImplementedException();
        }

        public Proveedores Insertar(Proveedores entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Proveedores!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}