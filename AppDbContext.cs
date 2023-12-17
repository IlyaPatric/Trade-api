using Microsoft.EntityFrameworkCore;
using TradeApi.Tables;

namespace TradeApi
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Users> users { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Manufacturer> manufacturer { get; set; }
        public DbSet<Provider> provider { get; set; }
        public DbSet<Product> product { get; set; }
    }
}
