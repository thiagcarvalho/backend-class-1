using PetShop.Manager.Persistence.DataModels.Security;
using PetShop.Manager.Persistence.DataModels.Store;

namespace PetShop.Manager.Persistence.DataModels
{
    public static class MemoryStorage
    {
        public static Dictionary<int, UserDataModel> Users { get; private set; } = new()
        {
            [1] = new UserDataModel
            {
                Id = 1,
                Name = "Admin",
                Email = "admin@example.com",
                Password = "Admin!",
                CreatedAt = DateTime.Now,
                CreatedBy = "System"
            },
            [2] = new UserDataModel
            {
                Id = 2,
                Name = "User One",
                Email = "userone@example.com",
                Password = "Userone!",
                CreatedAt = DateTime.Now,
                CreatedBy = "System",
            }
        };

        public static Dictionary<int, RoleDataModel> Roles = new Dictionary<int, RoleDataModel>
        {
            [1] = new RoleDataModel
            {
                Id = 1,
                Role = "Admin",
                CreatedAt = DateTime.Now,
                CreatedBy = "System"
            },
            [2] = new RoleDataModel
            {
                Id = 2,
                Role = "Public",
                CreatedAt = DateTime.Now,
                CreatedBy = "System"
            }
        };

        public static Dictionary<int, UserRoleDataModel> UserRoles = new Dictionary<int, UserRoleDataModel>
        {
            [1] = new UserRoleDataModel
            {
                Id = 1,
                UserId = 1,
                RoleId = 1,
                CreatedAt = DateTime.Now,
                CreatedBy = "System"
            },
            [2] = new UserRoleDataModel
            {
                Id = 2,
                UserId = 2,
                RoleId = 2,
                CreatedAt = DateTime.Now,
                CreatedBy = "System"
            },
        };

        public static Dictionary<int, PetDataModel> Pets = new Dictionary<int, PetDataModel>
        {
            [0] = new PetDataModel
            {
                Id = 0,
                Name = "Spike",
                Type = "Dog",
                CreatedAt = DateTime.Now,
                CreatedBy = "System"
            }
        };


        public static Dictionary<int, CustomerDataModel> Customers = new Dictionary<int, CustomerDataModel>
        {
            [1] = new CustomerDataModel
            {
                Id = 1,
                Name = "John Three Sixteen",
                Cpf = "01234567890",
                Email = "john@example.com",
                CreatedAt = DateTime.Now,
                CreatedBy = "System"
            }
        };
    }
}
