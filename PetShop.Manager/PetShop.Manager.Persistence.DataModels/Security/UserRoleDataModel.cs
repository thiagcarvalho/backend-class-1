namespace PetShop.Manager.Persistence.DataModels.Security
{
    public class UserRoleDataModel : DataModelBase
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }
    }
}
