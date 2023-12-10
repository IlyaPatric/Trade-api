using Microsoft.EntityFrameworkCore;
using TradeApi.Tables;

namespace TradeApi
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Users> users { get; set; }
    }
}
