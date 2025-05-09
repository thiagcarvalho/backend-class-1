using System.ComponentModel.DataAnnotations;

namespace PetShop.Manager.Application.Contracts.Models.InputModels.Security
{
    public class UserCredentialsInputModel
    {
        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
