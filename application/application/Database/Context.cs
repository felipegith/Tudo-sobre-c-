using application.Models;
using Microsoft.EntityFrameworkCore;

namespace application.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Palavra> Palavras {get; set;}
    }
}
