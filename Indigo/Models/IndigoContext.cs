using Microsoft.EntityFrameworkCore;

namespace Indigo.Models
{
    public class IndigoContext:DbContext
    {
        public IndigoContext(DbContextOptions<IndigoContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<AppUser> Users { get; set; }

    }
}
