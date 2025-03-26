using PetShop.Manager.Domain.Interfaces;

namespace PetShop.Manager.Domain
{
    public abstract class AnimalBase : BusinessObjectBase, IAnimal
    {
        public string Name { get; set; } = string.Empty;

        public DateTime? Birthdary { get; set; }
    }
}
