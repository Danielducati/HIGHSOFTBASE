namespace HIGHSOFTBASE.Models

{
    public class Servicio
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Duracion { get; set; }

        // Relación con citas
        public ICollection<Cita>? Citas { get; set; }
    }
}
