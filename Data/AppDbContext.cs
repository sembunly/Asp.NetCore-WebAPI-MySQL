using Microsoft.EntityFrameworkCore;
using FootwearInventory.Api.Models;

namespace FootwearInventory.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Footwear> Footwears { get; set; }
    }
}