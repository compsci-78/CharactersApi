using AutoMapper;
using CharactersApi.Models;
using CharactersApi.Models.Dtos;
using System.Drawing.Drawing2D;

namespace CharactersApi.Profiles
{
    public class MovieProfile:Profile
    {
        public MovieProfile()
        {
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<Movie, ReadMovieDto>()
                .ForMember(dto => dto.Characters, options =>
                options.MapFrom(movieDomain => movieDomain.Characters.Select(character => $"api/v1/charachters/{character.Id}").ToList()));
        }
    }
}
