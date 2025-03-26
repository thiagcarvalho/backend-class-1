using Microsoft.Extensions.DependencyInjection;
using PetShop.Manager.Application.Contracts.Interfaces.Persistence.Commands.Store;
using PetShop.Manager.Application.Contracts.Interfaces.Persistence.Queries.Security;
using PetShop.Manager.Application.Contracts.Interfaces.Persistence.Queries.Store;
using PetShop.Manager.Application.Contracts.Interfaces.Services.Security;
using PetShop.Manager.Application.Contracts.Interfaces.Services.Store;
using PetShop.Manager.Application.Services.Security;
using PetShop.Manager.Application.Services.Store;
using PetShop.Manager.Persistence.Command.Store;
using PetShop.Manager.Persistence.Query.Security;
using PetShop.Manager.Persistence.Query.Store;

namespace PetShop.Manager.Application
{
    public static class Config
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserQueryRepository, UserQueryRepository>();
            services.AddScoped<IRoleQueryRepository, RoleQueryRepository>();
            services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
            services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IJwtService, JwtService>();
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
