using Microsoft.AspNetCore.Mvc;
using PetShop.Manager.Domain.Services;

namespace Petshop.Manager.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IPetServices _petServices;
    private readonly ICustomerService _customerService;
    private readonly IOrderService _orderService;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        IPetServices petServices,
        ICustomerService customerService,
        IOrderService orderService)
    {
        _logger = logger;
        _petServices = petServices;
        _customerService = customerService;
        _orderService = orderService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray(); 
    }
}
