using DotNet7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

namespace DotNet7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {

        private static List<Character> characters = new List<Character> {
            new Character(),
            new Character {Id =1, Name = "Sam"}
    };


        [HttpGet]
        [Route(("GetAll"))]
        public ActionResult<List<Character>> GetAll()
        {
            return Ok(characters);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<List<Character>> GetSingle(int id)
        {
            return Ok(characters.FirstOrDefault(c => c.Id == id));
        }

        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter)
        {

            characters.Add(newCharacter);
            return Ok(characters);
        }
    }
}
