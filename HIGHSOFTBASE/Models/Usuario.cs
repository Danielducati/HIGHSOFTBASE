using System;
using System.ComponentModel.DataAnnotations;

namespace HIGHSOFTBASE.Models
{
    public class Usuario
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
        public string Rol { get; set; } // Admin, Usuario, etc.

        // Campos de control
        public bool Activo { get; set; } = true; // por defecto activo
        public DateTime? UltimaConexion { get; set; }
    }
}
