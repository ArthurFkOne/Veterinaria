using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Veterinaria_Web.Models.Entities;

namespace Veterinaria_Web.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<Articulo> Articulo { get; set; }
        public virtual DbSet<Citas> Cita { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Promocion>Promocion  { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factura>()
                .HasMany(e => e.Articulo)
                .WithMany(e => e.Facturas)
                .UsingEntity<FacturaProducto>(
                    l => l.HasOne<Articulo>().WithMany().HasForeignKey(e => e.PkArticulo),
                    r => r.HasOne<Factura>().WithMany().HasForeignKey(e => e.PkFactura));
        }

    }
}
