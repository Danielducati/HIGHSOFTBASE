﻿namespace HIGHSOFTBASE.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;

        // Relación con citas
        public ICollection<Cita>? Citas { get; set; }
    }
}
