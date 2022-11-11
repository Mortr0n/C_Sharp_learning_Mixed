using Microsoft.EntityFrameworkCore;

namespace BethanysPies.Models
{
    public class BethanysPiesDbContext: DbContext
    {
        public BethanysPiesDbContext(DbContextOptions<BethanysPiesDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }
    } 
}
