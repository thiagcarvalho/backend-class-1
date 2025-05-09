namespace PetShop.Manager.Domain.Interfaces
{
    public interface IBusinessObject
    {
        int Id { get; set; }

        DateTime CreatedAt { get; set; }

        string CreatedBy { get; set; }

        DateTime? ModifiedAt { get; set; }

        string? ModifiedBy { get; set; }
    }
}
