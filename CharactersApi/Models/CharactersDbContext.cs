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

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Character>().HasData(new Character {Id = 1,Name="Character_A",Alias="Any",Gender="Male",Picture="http://puctureUrl.com"});
            modelBuilder.Entity<Character>().HasData(new Character {Id = 2,Name="Character_B",Alias="Any",Gender="Female",Picture="http://puctureUrl.com"});
            modelBuilder.Entity<Character>().HasData(new Character {Id = 3,Name="Character_C",Alias="Any",Gender="Female",Picture="http://puctureUrl.com"});

            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 1, Name = "Franchies_A", Description = "Any"});
            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 2, Name = "Franchies_B", Description = "Any"});
            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 3, Name = "Franchies_C", Description = "Any"});

            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 1,Title="Movie_A",Genre="Action",Year="1999",Director="Someone",Picture= "http://puctureUrl.com",Trailer= "http://videoProvider.com",FranchiseId = 1});
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 2,Title="Movie_B",Genre="Comedy",Year="1999",Director="Someone",Picture= "http://puctureUrl.com",Trailer= "http://videoProvider.com", FranchiseId = 1 });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 3,Title="Movie_C",Genre="Romantic",Year="1999",Director="Someone",Picture= "http://puctureUrl.com",Trailer= "http://videoProvider.com", FranchiseId = 2 });

            // Seed m2m Character-Movie. Need to define m2m and access linking table
            modelBuilder.Entity<Character>()
                .HasMany(c => c.Movies)
                .WithMany(m => m.Characters)
                .UsingEntity<Dictionary<string, object>>(
                    "CharacterMovie",
                    r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    l => l.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
                    je =>
                    {
                        je.HasKey("CharacterId", "MovieId");
                        je.HasData(
                            new { CharacterId = 1, MovieId = 1 },
                            new { CharacterId = 1, MovieId = 2 },
                            new { CharacterId = 1, MovieId = 3 },
                            new { CharacterId = 2, MovieId = 1 },
                            new { CharacterId = 3, MovieId = 1 }                            
                        );
                    });
        }
    }
}
