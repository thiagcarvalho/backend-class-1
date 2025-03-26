namespace PetShop.Manager.Application.Contracts.Models.ViewModels.Store
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime? Birthday { get; set; }

        public required string Cpf { get; set; }

        public string? Email { get; set; }
    }
}
