using EFCoreDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ContosoUniversityContext db;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            ContosoUniversityContext db)
        {
            _logger = logger;
            this.db = db;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Course> Get()
        {
            return db.Course.ToList();

            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}