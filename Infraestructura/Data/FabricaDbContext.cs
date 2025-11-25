using FabricaNube.Core.Entidades;
using Microsoft.EntityFrameworkCore;

namespace FabricaNube.Infraestructura.Data
{
    public class FabricaDbContext : DbContext
    {
        public FabricaDbContext(DbContextOptions<FabricaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<LoteProduccion> LotesProduccion { get; set; }
        public DbSet<SolicitudLeche> SolicitudesLeche { get; set; }
        public DbSet<SolicitudDemanda>SolicitudesDemanda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}


