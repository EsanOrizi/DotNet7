using AutoMapper;
using DotNet7.Dtos.Character;
using DotNet7.Models;

namespace DotNet7
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
    }
}
