namespace HIGHSOFTBASE.Models

using System;
using System.ComponentModel.DataAnnotations;

namespace TU_PROYECTO.Models   // cambia TU_PROYECTO por el namespace real (ej: HIGHSOFT)

{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;

        // Relación con citas
        public ICollection<Cita>? Citas { get; set; }


        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        // Puedes tener un Rol para clientes si aplica, sino quita este campo
        public string Rol { get; set; } = "Cliente";

        // No requerido al crear
        public string Estado { get; set; } = "Activo";

        // Nullable: puede ser null al crear
        public DateTime? UltimaConexion { get; set; }

    }
}
