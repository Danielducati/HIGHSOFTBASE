using System;
using System.ComponentModel.DataAnnotations;

namespace HIGHSOFTBASE.Models
{
    public class Cita
    {
        public int Id { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }


        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; }

        public int EmpleadoId { get; set; }
        public EmpleadoAgenda Empleado { get; set; }
        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public EstadoCita Estado { get; set; } = EstadoCita.Pendiente;
    }
}
