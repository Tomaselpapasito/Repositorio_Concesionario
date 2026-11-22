using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_dominio.Entidades
{
    public class Roles
    {
        public int ID { get; set; }
        public string? Nombre { get; set; }
        public int Usuario { get; set; }

        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }


        [NotMapped] public List<Permisos>? Permisos { get; set; }

        public bool Validar()
        {
            throw new NotImplementedException();
        }
    }
}
