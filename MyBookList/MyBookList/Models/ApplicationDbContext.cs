using Microsoft.EntityFrameworkCore;

namespace MyBookList.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

    }
}
