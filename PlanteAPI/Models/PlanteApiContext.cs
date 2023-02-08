using Microsoft.EntityFrameworkCore;

namespace PlanteAPI.Models
{
    public class PlanteApiContext : DbContext
    {
        public PlanteApiContext(DbContextOptions<PlanteApiContext> options) : base(options) { }


        public DbSet<Plante> Plantes { get; set; }
    }
}
