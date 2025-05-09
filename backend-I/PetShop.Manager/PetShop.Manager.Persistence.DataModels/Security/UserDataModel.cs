namespace PetShop.Manager.Persistence.DataModels.Security
{
    public class UserDataModel : DataModelBase
    {
        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }
    }
}
