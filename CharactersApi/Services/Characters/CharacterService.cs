using CharactersApi.Exceptions;
using CharactersApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CharactersApi.Services.Characters
{
    public class CharacterService : ICharacterService
    {
        private readonly CharactersDbContext _context;
        public CharacterService(CharactersDbContext context)
        {
            _context = context;
        }
        public Task<Character> AddCaracter(Character character)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCharacter(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Character>> GetAllCharacters()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task<Character> GetCharacterById(int id)
        {
            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                throw new CharacterNotFoundException(id);
            }

            return character;
        }

        public Task<Character> UpdateCharacter(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
