using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace backend.Models
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        IConfiguration Configuration { get; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                string connection = Configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connection);
            }
    }
}
