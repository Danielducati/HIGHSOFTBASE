using System;
using System.ComponentModel.DataAnnotations;

namespace HIGHSOFTBASE.Models
{
    public class Cita
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }   // Ej: "Corte de Cabello - Juan Pérez"

        [Required]
        public DateTime FechaInicio { get; set; }

        

        // Relación con cliente
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        // Relación con servicio
        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; }

        // Relación con empleado
        public int EmpleadoId { get; set; }
        public EmpleadoAgenda Empleado { get; set; }

        [Required]
        public EstadoCita Estado { get; set; } = EstadoCita.Pendiente;
    }
}
