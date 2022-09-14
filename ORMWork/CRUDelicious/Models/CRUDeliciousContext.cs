using Microsoft.EntityFrameworkCore;
namespace CRUDelicious.Models
{ 
    // the CRUDeliciousContext class representing a session with our MySQL 
    // database allowing us to query for or save data
    public class CRUDeliciousContext : DbContext 
    { 
        public CRUDeliciousContext(DbContextOptions options) : base(options) { }
        // the "Monsters" table name will come from the DbSet variable name
        // public DbSet<Monster> Monsters { get; set; }
        public DbSet<Dish> Dishes { get; set; }
    }
}
