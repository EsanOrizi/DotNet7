using DotNet7.Dtos.Character;
using DotNet7.Dtos.Weapon;
using DotNet7.Models;
using DotNet7.Services.WeaponService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNet7.Controllers
{


    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponService weaponService;

        public WeaponController(IWeaponService weaponService)
        {
            this.weaponService = weaponService;
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddWeapon(AddWeaponDto newWeaponm)
        {
            return Ok(await weaponService.AddWeapon(newWeaponm));
        }

    }
}
