using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using lib_repositorio.Interfaces;

namespace lib_repositorio.Implementaciones
{
    public class ComprasAplicacion : IComprasAplicacion
	{
        private IConexion IConexion;

        public ComprasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Compras Actualizar(Compras entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Compras>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Compras Borrar(Compras entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Compras!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Compras> Buscar(Compras entidad)
        {
            return this.IConexion.Compras!
                .Include(x => x._Proveedor)
                .Where(x => x.Numero_Factura!.Contains(entidad.Numero_Factura!))
                .ToList();
        }

        public List<Compras> Consultar()
        {
            return this.IConexion.Compras!
                .Take(5).ToList();
        }

        public Compras Insertar(Compras entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Compras!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }


    }
}