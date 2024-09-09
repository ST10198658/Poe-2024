using Microsoft.EntityFrameworkCore;

namespace Poe.Models
{
    public class PoeDbContext : DbContext
    {
        public DbSet<Lecturer> Lecturers { get; set; }

        public PoeDbContext(DbContextOptions<PoeDbContext>options)
            : base(options)
        {
            
        }
    }
}
