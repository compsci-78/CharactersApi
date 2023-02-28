using CharactersApi.Exceptions;
using CharactersApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CharactersApi.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly CharactersDbContext _context;
        public MovieService(CharactersDbContext context)
        {
            _context = context;
        }
        public async Task<Movie> AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                throw new MovieNotFoundException(id);
            }
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _context.Movies.Include(x=>x.Characters).ToListAsync();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await _context.Movies.Include(x=>x.Characters).FirstOrDefaultAsync(x=>x.Id==id);

            if (movie == null)
            {
                throw new MovieNotFoundException(id);
            }

            return movie;
        }
        public async Task<Movie> UpdateMovie(Movie movie)
        {
            var foundMovie= await _context.Movies.AnyAsync(x => x.Id == movie.Id);
            if (!foundMovie)
            {
                throw new MovieNotFoundException(movie.Id);
            }
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return movie;
        }
        public async Task UpdateMovieCharacters(int movieId, List<int> charactersId)
        {
            var foundMovie = await _context.Movies.AnyAsync(x => x.Id == movieId);
            if (!foundMovie)
            {
                throw new MovieNotFoundException(movieId);
            }

            // Finding the movie with its characters
            var movieToUpdateCharacters = await _context.Movies
                .Include(m => m.Characters)
                .Where(m => m.Id == movieId)
                .FirstAsync();

            // Loop through characters, try and assign to movie            
             var characters = new List<Character>();

            foreach (var id in charactersId)
            {
                var character = await _context.Characters.FindAsync(id);
                if (character == null)
                    // Record doesnt exist: https://docs.microsoft.com/en-us/previous-versions/dotnet/netframework-4.0/ms229021(v=vs.100)?redirectedfrom=MSDN
                    throw new KeyNotFoundException($"character with {id} not found");
                characters.Add(character);
            }
            movieToUpdateCharacters.Characters = characters;
            _context.Entry(movieToUpdateCharacters).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
        }
    }
}
