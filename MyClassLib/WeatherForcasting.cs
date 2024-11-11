using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLib
{
    public class WeatherForcasting
    {
        string[] summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherResponsedata GetWeatherData()
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
            {
               var forcastdata = new WeatherForecast
                 (
                 DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                 Random.Shared.Next(-20, 55),
                 summaries[Random.Shared.Next(summaries.Length)]
                  );

                return new WeatherResponse
                {
                    date = forcastdata.Date.ToDateTime(new TimeOnly()).Ticks,
                    temperatureC = forcastdata.TemperatureC,
                    summary =forcastdata.Summary,
                    temperatureF =forcastdata.TemperatureF

                };

            }).ToArray();

            return new WeatherResponsedata
            {
                Data = forecast
            };



        }
      

    }

    internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

    public class WeatherResponsedata
    {
        public WeatherResponse[]? Data { get; set; }
    }

    public class WeatherResponse
    {
        public long date { get; set; }
        public int temperatureC { get; set; }
        public string? summary { get; set; }
        public int temperatureF { get; set; }
    }
}
