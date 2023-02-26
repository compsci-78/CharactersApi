using CharactersApi.Models;

namespace CharactersApi.Services.Characters
{
    public interface ICharacterService
    {
        Task<IEnumerable<Character>> GetAllCharacters();        
        Task<Character> GetCharacterById(int id);
        Task<Character> AddCaracter(Character character);
        Task DeleteGuitar(int id);
        Task<Character> UpdateCharacter(Character character);
    }
}
