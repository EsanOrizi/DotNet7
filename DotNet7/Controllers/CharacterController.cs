﻿using DotNet7.Models;
using DotNet7.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

namespace DotNet7.Controllers
{
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
        public async Task<ActionResult<List<Character>>> GetAll()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Character>>> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> AddCharacter(Character newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
    }
}