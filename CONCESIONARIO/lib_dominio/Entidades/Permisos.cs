using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lib_dominio.Entidades
{
    public class Permisos
    {
        public int ID { get; set; }
        public int Rol { get; set; }
        public string? Descripcion { get; set; }

        [ForeignKey("Rol")] public Roles? _Rol { get; set; }

        public bool Validar()
        {
            throw new NotImplementedException();
        }
    }
}
