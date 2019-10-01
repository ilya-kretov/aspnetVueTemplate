using System;
using System.Collections.Generic;
using System.Linq;
using aspnetVue.Models;

namespace aspnetVue.Providers
{
    public class WeatherProviderFake : IWeatherProvider
    {
        private readonly string[] _summaries = {
            "Дубак", "Холодрыга", "Холодно", "Прохладно", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private List<WeatherForecast> WeatherForecasts { get; set; }

        public WeatherProviderFake()
        {
            Initialize(50);
        }

        private void Initialize(int quantity)
        {
            var rng = new Random();
            WeatherForecasts = Enumerable.Range(1, quantity).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = _summaries[rng.Next(_summaries.Length)]
            }).ToList();
        }

        public List<WeatherForecast> GetForecasts()
        {
            return WeatherForecasts;
        }
    }
}
