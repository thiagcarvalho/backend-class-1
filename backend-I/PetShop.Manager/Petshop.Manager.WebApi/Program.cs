using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PetShop.Manager.Application;
using PetShop.Manager.Application.Contracts.Interfaces;
using PetShop.Manager.WebApi.Config;
using PetShop.Manager.WebApi.Middlewares;
using PetShop.Manager.WebApi.Security.Basic;
using PetShop.Manager.WebApi.Services;
using System.Security.Claims;
using System.Text.Json;

namespace PetShop.Manager.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<PaymentsConfig>(builder.Configuration.GetSection(nameof(PaymentsConfig)));

            // Service lifecycles examples
            builder.Services.AddSingleton<IMySingletonService, MySingletonService>();
            builder.Services.AddScoped<IMyScopedService, MyScopedService>();
            builder.Services.AddTransient<IMyTransientService, MyTransientService>();

            builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddHttpClient();

            // Application Services
            builder.Services.AddApplicationServices();

            // Repositories
            builder.Services.AddRepositories();

            builder.Services.AddSingleton(serviceProvider =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
                });

                return config.CreateMapper();
            });

            // OAuth Authentication (Google as Identity Provider)
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddOAuth("OAuthProvider", options =>
            {
                // https://accounts.google.com/.well-known/openid-configuration

                options.ClientId = builder.Configuration["OAuthGoogle:ClientId"]!;
                options.ClientSecret = builder.Configuration["OAuthGoogle:ClientSecret"]!;
                options.CallbackPath = builder.Configuration["OAuthGoogle:CallbackPath"]!;

                options.AuthorizationEndpoint = builder.Configuration["OAuthGoogle:AuthorizationEndpoint"]!;
                options.TokenEndpoint = builder.Configuration["OAuthGoogle:TokenEndpoint"]!;
                options.UserInformationEndpoint = builder.Configuration["OAuthGoogle:UserInfoEndpoint"]!;

                options.Scope.Add("profile");
                options.Scope.Add("email");

                // Should store and handle the token refresh 
                // the cookie then carries Refresh and Access Tokens
                options.SaveTokens = true;

                // Map claims from the OAuth provider
                options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
                options.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
                options.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");

                options.Events = new OAuthEvents
                {
                    OnCreatingTicket = async context =>
                    {
                        var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", context.AccessToken);

                        var response = await context.Backchannel.SendAsync(request);
                        response.EnsureSuccessStatusCode();

                        var user = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
                        context.RunClaimActions(user.RootElement);
                    }
                };
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                // Self issued tokens
                //options.TokenValidationParameters = new TokenValidationParameters
                //{
                //    ValidateIssuer = true,
                //    ValidateAudience = true,
                //    ValidateLifetime = true,
                //    ValidateIssuerSigningKey = true,
                //    ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
                //    ValidAudience = builder.Configuration["JwtConfig:Audience"],
                //    IssuerSigningKey =
                //        new SymmetricSecurityKey(
                //            Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:SigningKey"] ?? throw new ApplicationException()))
                //};
                // End of Self issued tokens configuration

                // Keycloak issued tokens
                // Check the README file to setup Keycloak using docker
                // https://www.keycloak.org/getting-started/getting-started-docker

                options.Authority = builder.Configuration["Authentication:Keycloak:Authority"];
                options.Audience = builder.Configuration["Authentication:Keycloak:Audience"];
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["Authentication:Keycloak:Authority"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["Authentication:Keycloak:Audience"],
                    ValidateLifetime = true,
                    RoleClaimType = "resource_access",
                    NameClaimType = "preferred_username"
                };

                options.Events = new JwtBearerEvents
                {
                    OnChallenge = context =>
                    {
                        context.Response.Redirect("http://localhost:8080/realms/petshop-manager/protocol/openid-connect/auth");
                        context.HandleResponse();
                        return Task.CompletedTask;
                    }
                };

                options.Validate();
            })
            .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("Basic", null)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                };
                options.Events.OnRedirectToAccessDenied = context =>
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    return Task.CompletedTask;
                };
            });

            builder.Services.AddAuthorization();

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Basic"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Basic"
                            }
                        },
                        new List<string>()
                    }
                });
            });

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

            // Custom middlewares
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<LoggerMiddleware>();
            app.UseMiddleware<CustomReponseHeadersMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
