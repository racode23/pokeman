using AutoMapper;
using pokeman.Dto;
using pokeman.Models;

namespace pokeman.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
        }
    }
}
