using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class TodoDbContext : DbContext 
    {
        public TodoDbContext(DbContextOptions options) : base(options) { }
        public DbSet<todo>  Todos { get; set; }
    }
}
