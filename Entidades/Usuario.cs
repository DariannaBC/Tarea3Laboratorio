using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea3Laboratorio.Entidades
{
   public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }
        public string Clave { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        public int RolID { get; set; }
        public string Alias { get; set; }
        public bool Activo { get; set; }

        [ForeignKey("RolID")]
        public virtual Roles Rol { get; set; }
    }
}
