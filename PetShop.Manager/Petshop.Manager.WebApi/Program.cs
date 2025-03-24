using PetShop.Manager.Domain.Services;
using Petshop.Manager.WebApi.Middlewares;
using PetShop.Manager.Application.Contracts.Interfaces;
using Petshop.Manager.WebApi.Security;
using PetShop.Manager.Application;
using PetShop.Manager.Application.Queries.Security;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IPetServices, PetServices>();
builder.Services.AddScoped<ICustomerService, CustomerServices>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();


builder.Services.AddSingleton(serviceProvider => {
    var config = new MapperConfiguration(cfg => { cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies()); });

    return config.CreateMapper();
});

builder.Services.AddRepositories();
builder.Services.AddControllers();
builder.Services.AddAuthentication("Basic")
    .AddScheme<Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions, BasicAuthenticationHandler>("Basic", null);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
