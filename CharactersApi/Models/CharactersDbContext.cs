using Microsoft.EntityFrameworkCore;

namespace CharactersApi.Models
{
    public class CharactersDbContext:DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet <Character> Characters { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        public CharactersDbContext(DbContextOptions options):base(options)
        {            
        }

    }
}
