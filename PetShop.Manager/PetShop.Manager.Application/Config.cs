using Microsoft.Extensions.DependencyInjection;
using PetShop.Manager.Application.Contracts.Interfaces.Persistence;
using PetShop.Manager.Persistence.Query.Security;

namespace PetShop.Manager.Application
{
    public static class Config
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserQueryRepository, UserQueryRepository>();
            services.AddScoped<IRoleQueryRepository, RoleQueryRepository>();
        }
    }
}
