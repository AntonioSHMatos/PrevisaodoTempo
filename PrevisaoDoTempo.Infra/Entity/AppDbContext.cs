using PrevisaoDoTempo.Modelo;
using Microsoft.EntityFrameworkCore;



namespace PrevisaoDoTempo.Infra.Entity
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Previsao> Previsao { get; set; }
    }
}
