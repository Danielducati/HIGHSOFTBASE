using System.ComponentModel.DataAnnotations;

namespace HIGHSOFT.Models
{
    public class Servicio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(150)]
        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        [Range(0, 999999)]
        public decimal Precio { get; set; } = 0m;

        // Duración en minutos (opcional)
        public int? DuracionMinutos { get; set; }

        // FK a CategoriaServicio
        [Display(Name = "Categoría")]
        [Required(ErrorMessage = "La categoría es obligatoria")]
        public int CategoriaServicioId { get; set; }

        // Navegación
        public CategoriaServicio? CategoriaServicio { get; set; }

        public string Estado { get; set; } = "Activo";

        public DateTime? CreadoEn { get; set; } = DateTime.UtcNow;
    }
}
