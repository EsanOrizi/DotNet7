using DotNet7.Dtos.Fight;
using DotNet7.Models;
using DotNet7.Services.FightService;
using Microsoft.AspNetCore.Mvc;

namespace DotNet7.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class FightController : ControllerBase
        {
        private readonly IFightService fightService;

        public FightController(IFightService fightService)
        {
            this.fightService = fightService;
        }


        [HttpPost("Weapon")]
        public async Task<ActionResult<ServiceResponse<AttackResultDto>>> WeaponAttack(WeaponAttackDto request)
        {
            return Ok(await fightService.WeaponAttack(request));
        }

    }
}
