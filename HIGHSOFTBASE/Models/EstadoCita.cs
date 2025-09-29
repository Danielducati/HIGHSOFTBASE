namespace HIGHSOFTBASE.Models
{
    public enum EstadoCita
    {
        Pendiente,   // cuando el cliente la crea
        Programada,  // cuando la apruebas
        Cumplida,    // cuando se realiza
        Cancelada    // cuando se rechaza o cancela
    }
}
