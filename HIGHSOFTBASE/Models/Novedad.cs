using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIGHSOFTBASE.Models
{
    public class Novedad
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Título de la Novedad")]
        public string Titulo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Display(Name = "Estado")]
        public bool Activo { get; set; }

        [Required]
        [Display(Name = "Fecha y Hora")]
        public DateTime FechaHora { get; set; }

        // 🔗 Relación con Empleado
        [Display(Name = "Empleado")]
        public int EmpleadoId { get; set; }
        public EmpleadoAgenda Empleado { get; set; }
    }
}
