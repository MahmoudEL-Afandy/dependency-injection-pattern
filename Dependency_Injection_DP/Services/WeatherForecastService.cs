namespace Dependency_Injection_DP.Services
{
    public class WeatherForecastService :IWeatherForecastService
    {



        // i will implement the logging message on it, and i will make the consturctor get the ILogger
        // the logging message will be shown when the endpoint is called, it helps to catch the error and debug the application
        private readonly ILogger<WeatherForecastService> _logger;

        public WeatherForecastService(ILogger<WeatherForecastService> logger)
        {
            _logger = logger;
        }



        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> GetForecasts()
        {
            _logger.LogInformation("Getting weather forecasts");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

        }

    }
}
