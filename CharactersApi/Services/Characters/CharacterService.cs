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

        public async Task DeleteCharacter(int id)
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

        public async Task<Character> UpdateCharacter(Character character)
        {
            var foundCharacter = await _context.Characters.AnyAsync(x => x.Id == character.Id);
            if (!foundCharacter)
            {
                throw new CharacterNotFoundException(character.Id);
            }
            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return character;
        }
    }
}
