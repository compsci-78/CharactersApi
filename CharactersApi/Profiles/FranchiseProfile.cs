using AutoMapper;
using CharactersApi.Models.Dtos;
using CharactersApi.Models;

namespace CharactersApi.Profiles
{
    public class FranchiseProfile:Profile
    {
        public FranchiseProfile()
        {
            CreateMap<CreateFranchiseDto, Franchise>();
            CreateMap<Franchise, ReadFranchiseDto>()
                .ForMember(dto => dto.Movies, options =>
                options.MapFrom(franchiseDomain => franchiseDomain.Movies.Select(movie => $"api/v1/movies/{movie.Id}").ToList()));
            CreateMap<UpdateFranchiseDto, Franchise>();
        }
    }
}
