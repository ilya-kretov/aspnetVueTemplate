using System.Collections.Generic;
using aspnetVue.Models;

namespace aspnetVue.Providers
{
    public interface IWeatherProvider
    {
        List<WeatherForecast> GetForecasts();
    }
}
