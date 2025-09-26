using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HIGHSOFT.Models
{
    public class CategoriaServicio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Descripcion { get; set; }

        public string Estado { get; set; } = "Activo";

        // Relación 1 (categoria) => N (servicios)
        public ICollection<Servicio>? Servicios { get; set; }
    }
}
