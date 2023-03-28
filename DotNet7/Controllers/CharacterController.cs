using DotNet7.Dtos.Character;
using DotNet7.Models;
using DotNet7.Services.CharacterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

namespace DotNet7.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {

       
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }


        [HttpGet]
        [Route(("GetAll"))]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetAll()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            if(response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> DeleteCharacter(int id)
        {
            var response = await _characterService.DeleteCharacter(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

    }
}
