using Microsoft.EntityFrameworkCore;
using HIGHSOFTBASE.Models;

namespace HIGHSOFTBASE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tablas
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<EmpleadoAgenda> Empleados { get; set; }
        public DbSet<Cita> Citas { get; set; }
    }
}
