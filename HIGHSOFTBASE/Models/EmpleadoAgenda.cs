namespace HIGHSOFTBASE.Models
{
    public class EmpleadoAgenda
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;

        // Relación con citas
        public ICollection<Cita>? Citas { get; set; }
    }
}
