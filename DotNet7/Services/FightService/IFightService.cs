using DotNet7.Dtos.Fight;
using DotNet7.Models;

namespace DotNet7.Services.FightService
{
    public interface IFightService
    {
        Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request);
    }
}
