using System.ComponentModel.DataAnnotations;

namespace HIGHSOFTBASE.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        public string Tipo { get; set; } // Admin, Usuario, etc.

    }
}
