using Microsoft.EntityFrameworkCore;

namespace Lesson9.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Employee1> AmntEmployees { get; set; }
    }
}
