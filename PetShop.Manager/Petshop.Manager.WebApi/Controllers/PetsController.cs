using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Petshop.Manager.WebApi.Dto;


namespace Petshop.Manager.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        public static Dictionary<string, PetDto> Pets { get; set; } = [];

        [HttpPost]
        [Authorize(AuthenticationSchemes = $"Basic")]
        public IActionResult Post(PetDto pet)
        {
            Pets.Add(pet.Name, pet);
            return Created();
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name){
            if (Pets.ContainsKey(name)){
                return Ok(Pets[name]);
            }

            return NotFound();

        }
    }
}
