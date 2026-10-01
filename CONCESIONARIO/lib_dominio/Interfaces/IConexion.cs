using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_dominio.interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }
        DbSet<Personas>? Personas { get; set; }
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}