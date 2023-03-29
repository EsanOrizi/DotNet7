using DotNet7.Dtos.Character;
using DotNet7.Dtos.Weapon;
using DotNet7.Models;

namespace DotNet7.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);

    }
}
