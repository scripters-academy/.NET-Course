using Microsoft.EntityFrameworkCore;
using WorkifyApp.Models;

namespace WorkifyApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<WorkItem> WorkItems { get; set; }
    }
}
