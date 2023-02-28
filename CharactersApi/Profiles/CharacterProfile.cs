using AutoMapper;
using CharactersApi.Models.Dtos;
using CharactersApi.Models;

namespace CharactersApi.Profiles
{
    public class CharacterProfile:Profile
    {
        public CharacterProfile() 
        {
            CreateMap<Character, ReadCharacterDto>()
                .ForMember(dto => dto.Movies, options =>
                options.MapFrom(characterDomain => characterDomain.Movies.Select(movie => $"api/v1/movies/{movie.Id}").ToList()));
        }
    }
}
