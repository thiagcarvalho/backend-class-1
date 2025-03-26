namespace PetShop.Manager.Persistence.DataModels.Store
{
    public class CustomerDataModel : DataModelBase
    {
        public string Name { get; set; } = string.Empty;

        public DateTime? Birthday { get; set; }

        public required string Cpf { get; set; }

        public string? Email { get; set; }
    }
}
