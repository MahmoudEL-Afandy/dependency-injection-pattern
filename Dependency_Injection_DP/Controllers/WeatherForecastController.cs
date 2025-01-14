using Dependency_Injection_DP.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dependency_Injection_DP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        // it moved to WeatherForecastService
        
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        private readonly ILogger<WeatherForecastController> _logger;
        // after create it i must register it in the Program.cs to define lifetime of the instance 

        //private readonly WeatherForecastService _weatherForecastService;

        // the best practice of DI is to make the dependency on the Interfaces not on the class to improve the flexibility of the code
        // we can make it if we will implement it in many of class 
        // after implement IWeatherForecastService
        private readonly IWeatherForecastService _weatherForecastService; // this operation called inject

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService; // this operation called inject
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {




            // to implement web api, you should make the endpoint does not contain any business logic and only return the result
            // and you should create service to handle the business logic for this endpoint and inject it to the controller constructor 
            // so i will create WeatherForecastService class to handle the business logic for this controller, and move this business on it
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();



            // after i implemet the WeatherForecastService constuctor getting the ILogger , i must pass the Ilogger to create instance from WeatherForecastService
            //  so i need to create instance from logger,it's very defficult to do, so create new instance from WeatherForecastService be very defficult  
            //  so the Dependency injection in .net solve this problem
            //  by inject the WeatherForecastService to the controller constructor and the framework will create instance from it and pass ILogger to the WeatherForecastService
            //var services = new WeatherForecastService();
            //return services.GetForecasts();
            return _weatherForecastService.GetForecasts();
        }
    }
}
