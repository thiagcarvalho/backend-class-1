namespace PetShop.Manager.Domain.Models.Security
{
    public class User : BusinessObjectBase
    {
        public string? Login { get; set; }

        public string? Password { get; set; }

        public IEnumerable<string> Roles { get; set; } = [];
    }
}
