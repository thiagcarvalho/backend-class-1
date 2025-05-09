using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Manager.Application.Contracts.Interfaces.Services.Store;
using PetShop.Manager.Application.Contracts.Models.InputModels.Store;
using PetShop.Manager.WebApi.Config;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Manager.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(
            ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = Constants.AuthSchemes)]
        public IActionResult Post([Required] CustomerInputModel customer)
        {
            _customerService.Save(customer);
            return Created();
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = Constants.AuthSchemes)]
        public IActionResult Put (
            [FromRoute] int id,
            [FromBody, Required] CustomerInputModel customer
            )
        {
            customer.Id = id;
            _customerService.UpdateCustomer(id, customer);
            return NoContent();
        }


        [HttpGet("{cpf}")]
        [Authorize(AuthenticationSchemes = Constants.AuthSchemes)]
        public IActionResult Get(string cpf)
        {
            var customer = _customerService.GetByCpf(cpf);
            return customer is null ? NotFound() : Ok(customer);
        }

        [HttpPut("{cpf}/email")]
        [Authorize(AuthenticationSchemes = Constants.AuthSchemes)]
        public IActionResult Email(
            [FromRoute] string cpf,
            [FromBody, Required, EmailAddress] string email)
        {
            _customerService.ChangeEmail(cpf, email);
            return NoContent();
        }
        [HttpPost("{cpf}/pets/{petId}")]
        [Authorize(AuthenticationSchemes = Constants.AuthSchemes)]
        public IActionResult AddPet(
            [FromRoute] string cpf,
            [FromRoute] int petId)
        {
            _customerService.AddPet(cpf, petId);
            return Created();
        }

        [HttpDelete("{cpf}/pets/{petId}")]
        [Authorize(AuthenticationSchemes = Constants.AuthSchemes)]
        public IActionResult RemovePet(
            [FromRoute] string cpf,
            [FromRoute] int petId)
        {
            _customerService.RemovePet(cpf, petId);
            return NoContent();
        }

    }
}
