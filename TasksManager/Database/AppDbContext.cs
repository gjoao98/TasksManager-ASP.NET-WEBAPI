using Microsoft.EntityFrameworkCore;
using TasksManager.Models;

namespace TasksManager.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}
