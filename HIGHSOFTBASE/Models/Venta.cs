using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIGHSOFTBASE.Models
{
    public class Venta
    {
        [Key]
        public int VentaId { get; set; }

        [Required(ErrorMessage = "El servicio es obligatorio")]
        [StringLength(100)]
        public string Servicio { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor o igual a 0")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        [Required]
        public int EmpleadoId { get; set; }

        [ForeignKey("EmpleadoId")]
        public Empleado? Empleado { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }
    }
}

