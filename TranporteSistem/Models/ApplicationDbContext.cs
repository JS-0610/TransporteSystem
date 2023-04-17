using Microsoft.EntityFrameworkCore;

namespace TranporteSistem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Colaborador> Colaborador { get; set;}
        public DbSet<Sucursal> Sucursal { get; set;}
        public DbSet<SucursalColaborador> SucursalColaborador { get; set;}
        public DbSet<Transportista> Transportista { get; set;}
        public DbSet<Viaje> Viaje { get; set;}
        public DbSet<ViajeDetalle> ViajeDetalle { get; set;}
    }
}
