using Microsoft.EntityFrameworkCore;
using Lab.Models;

namespace Lab.Data
{
    public class CotizacionesContext : DbContext
    {
        public CotizacionesContext(DbContextOptions<CotizacionesContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //SQLITE COMO BACKEND
            optionsBuilder.UseSqlite("Data Source=cotizaciones.db");
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cotizacion> Cotizaciones {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().HasKey(x => x.Rut);
            base.OnModelCreating(modelBuilder);
        }
    
    }
}