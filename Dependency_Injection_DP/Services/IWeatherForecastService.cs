namespace Dependency_Injection_DP.Services
{
    public interface IWeatherForecastService
    {

        IEnumerable<WeatherForecast> GetForecasts();
    }
}