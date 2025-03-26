using System.ComponentModel.DataAnnotations;

namespace PetShop.Manager.Application.Contracts.Models.InputModels.Store
{
    public class CustomerInputModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "The Name is required")]
        public string Name { get; set; } = string.Empty;

        public DateTime? Birthday { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "The CPF must have 11 characters")]
        [Required(ErrorMessage = "The CPF is required")]
        public string? Cpf { get; set; }
    }
}
