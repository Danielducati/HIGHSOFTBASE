using HIGHSOFT.Models;
using HIGHSOFTBASE.Models;
using Microsoft.EntityFrameworkCore;
using TU_PROYECTO.Models;

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

        public DbSet<Novedad> Novedades { get; set; }


        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<CategoriaServicio> CategoriaServicios { get; set; }
        public DbSet<Servicio> Servicios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Índice único para el nombre de categoría (opcional pero recomendado)
            modelBuilder.Entity<CategoriaServicio>()
                .HasIndex(c => c.Nombre)
                .IsUnique();

            // Relación servicio -> categoria con restricción al eliminar
            modelBuilder.Entity<Servicio>()
                .HasOne(s => s.CategoriaServicio)
                .WithMany(c => c.Servicios)
                .HasForeignKey(s => s.CategoriaServicioId)
                .OnDelete(DeleteBehavior.Restrict);
        }



        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        
        


    }
}
