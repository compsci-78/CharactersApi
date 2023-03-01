using CharactersApi.Exceptions;
using CharactersApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CharactersApi.Services.Franchises
{
    public class FranchiseService:IFranchiseService
    {
        private readonly CharactersDbContext _context;
        public FranchiseService(CharactersDbContext context)
        {
            _context = context;
        }
        public async Task<Franchise> AddFranchise(Franchise franchise)
        {
            _context.Franchises.Add(franchise);
            await _context.SaveChangesAsync();
            return franchise;
        }

        public async Task DeleteFranchise(int id)
        {
            // In order to delete the frinchise we need to include movies with firnchise foreing key
            // This will set the foreing key to null for movies then deletes the franchise. Otherwhise 
            // the deletion won´t be possible because of relational integrity. 
            var franchise = await _context.Franchises.Include(f=>f.Movies).FirstOrDefaultAsync(f=>f.Id==id);

            if (franchise == null)
            {
                throw new FranchiseNotFoundException(id);
            }
            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();
        }

        public async  Task<IEnumerable<Character>> GetAllFranchiseCharacters(int franchiseId)
        {
            var foundFranchise = await _context.Franchises.AnyAsync(x => x.Id == franchiseId);

            if (!foundFranchise)
            {
                throw new FranchiseNotFoundException(franchiseId);
            }

            var franchise = await _context.Franchises.Include(f => f.Movies).ThenInclude(m=>m.Characters).FirstOrDefaultAsync(f => f.Id == franchiseId);
            var characters= new List <Character>();

            foreach (var movie in franchise.Movies)
            {
                foreach (var character in movie.Characters)
                {
                    characters.Add(character);
                }
            }
            return characters;
        }

        public async Task<IEnumerable<Movie>> GetAllFranchiseMovies(int franchiseId)
        {            
            var foundFranchise = await _context.Franchises.AnyAsync(x => x.Id == franchiseId);

            if (!foundFranchise)
            {
                throw new FranchiseNotFoundException(franchiseId);
            }

            var franchise = await _context.Franchises.Include(f=>f.Movies).SingleOrDefaultAsync(f=>f.Id == franchiseId);

            return franchise.Movies;
        }

        public async Task<IEnumerable<Franchise>> GetAllFranchises()
        {
            return await _context.Franchises.Include(f=>f.Movies).ToListAsync();
        }

        public async Task<Franchise> GetFranchiseById(int id)
        {
            var franchise = await _context.Franchises.Include(f=>f.Movies).FirstOrDefaultAsync(f=>f.Id==id);

            if (franchise == null)
            {
                throw new FranchiseNotFoundException(id);
            }

            return franchise;
        }

        public async Task<Franchise> UpdateFranchise(Franchise franchise)
        {
            var foundFranchise = await _context.Franchises.AnyAsync(x => x.Id == franchise.Id);

            if (!foundFranchise)
            {
                throw new FranchiseNotFoundException(franchise.Id);
            }
            _context.Entry(franchise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return franchise;
        }

        public async Task UpdateFranchiseMovies(int franchiseId, List<int> moviesId)
        {
            var foundFranchise = await _context.Franchises.AnyAsync(x => x.Id == franchiseId);
            if (!foundFranchise)
            {
                throw new FranchiseNotFoundException(franchiseId);
            }

            // Finding the franchise with its movies
            var franchiseToUpdateMovies = await _context.Franchises
                .Include(f => f.Movies)
                .Where(f => f.Id == franchiseId)
                .FirstAsync();

            // Loop through movies, try and assign to franchise            
            var movies = new List<Movie>();

            foreach (var id in moviesId)
            {
                var movie = await _context.Movies.FindAsync(id);
                if (movie == null)
                    // Record doesnt exist: https://docs.microsoft.com/en-us/previous-versions/dotnet/netframework-4.0/ms229021(v=vs.100)?redirectedfrom=MSDN
                    throw new KeyNotFoundException($"movie with {id} not found");
                movies.Add(movie);
            }
            franchiseToUpdateMovies.Movies = movies;
            _context.Entry(franchiseToUpdateMovies).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
