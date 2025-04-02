using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PetShop.Manager.Application.Contracts.Interfaces.Services.Store;
using PetShop.Manager.WebApi.Config;
using PetShop.Manager.Application.Contracts.Models.InputModels.Store;

namespace PetShop.Manager.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;
        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = Constants.AuthSchemes)]
        public IActionResult Post([Required] PetInputModel inputModel)
        {
            _petService.Save(inputModel);
            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = Constants.AuthSchemes)]
        public IActionResult Get(int id)
        {
            var pet = _petService.GetById(id);
            return pet is null ? NotFound() : Ok(pet);
        }
    }
}
