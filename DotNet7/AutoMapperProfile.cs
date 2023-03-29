using AutoMapper;
using dotnet_rpg.Dtos.Skill;
using DotNet7.Dtos.Character;
using DotNet7.Dtos.Fight;
using DotNet7.Dtos.Weapon;
using DotNet7.Migrations;
using DotNet7.Models;

namespace DotNet7
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<Skill, GetSkillDto>();
            CreateMap<Character, HighscoreDto>();
        }
    }
}
