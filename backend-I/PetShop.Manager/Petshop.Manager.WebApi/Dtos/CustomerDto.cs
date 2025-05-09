using System.ComponentModel.DataAnnotations;

namespace PetShop.Manager.WebApi.Dtos
{
    public class CustomerDto
    {
        [Required(ErrorMessage = "The Name is required")]
        public string Name { get; set; } = string.Empty;

        public DateTime? Birthday { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "The CPF must have 11 characters")]
        [Required(ErrorMessage = "The CPF is required")]
        public string? Cpf { get; set; }
    }
}
