using AutoMapper;
using PersonnalApi.Dto;
using PersonnalApi.Models;

namespace PersonnalApi.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PokeGame, PokeGameDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Country, CountryDto>();
        }
    }
}
