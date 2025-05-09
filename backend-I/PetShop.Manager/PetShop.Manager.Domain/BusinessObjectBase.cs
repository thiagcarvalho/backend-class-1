using PetShop.Manager.Domain.Interfaces;

namespace PetShop.Manager.Domain
{
    public abstract class BusinessObjectBase : IBusinessObject
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string CreatedBy { get; set; } = string.Empty;

        public DateTime? ModifiedAt { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
