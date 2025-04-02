using PetShop.Manager.Domain.ValueObjects;

namespace PetShop.Manager.Domain.Models.Store
{
    public class Customer : BusinessObjectBase
    {
        public string Name { get; set; } = string.Empty;

        public DateTime? Birthday { get; set; }

        public Cpf? Cpf { get; set; }

        public string? Email { get; set; }

        public IEnumerable<Pet> Pets { get; set; } = [];
    }
}
