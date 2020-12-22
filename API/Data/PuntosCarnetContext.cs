using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class PuntosCarnetContext : DbContext
    {
        public PuntosCarnetContext(DbContextOptions<PuntosCarnetContext> options) : base(options)
        {
        }

        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Conductor> Conductores { get; set; }
        public DbSet<RegistroInfraccion> RegistroInfracciones { get; set; }
        public DbSet<TipoInfraccion> TipoInfracciones { get; set; }
        public DbSet<VehiculosConductor> VehiculosConductores { get; set; }




    }
}