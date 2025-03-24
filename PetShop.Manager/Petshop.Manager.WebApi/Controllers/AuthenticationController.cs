using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Manager.Application.Contracts.Interfaces;
using PetShop.Manager.Application.Contracts.Models.InputModels;

namespace Petshop.Manager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpGet]
        [Route("basic")]
        public IActionResult Basic([FromHeader] UserCredentialsInputModel inputModel)
        {
            var user = _authenticationService.Authenticate(inputModel);
            if (user == null)
                return Unauthorized();

            return Ok(user);
        }

    }
}
