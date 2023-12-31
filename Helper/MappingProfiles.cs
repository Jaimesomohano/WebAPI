using AutoMapper;
using PokemonAPI.Dto;
using PokemonAPI.Models;

namespace PokemonAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Owner, OwnerDto>();
        }   
    }
}