using Microsoft.EntityFrameworkCore;

namespace QuickTaskAPI.Business.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Features.Entities.Task> Tasks { get; set; }
    }
}
