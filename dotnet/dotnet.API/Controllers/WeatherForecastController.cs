using Microsoft.AspNetCore.Mvc;

namespace dotnet.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild",
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // GET: /weatherforecast
        [HttpGet]
        public IEnumerable<WeatherForecast> GetAll()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index).ToString("yyyy-MM-dd"),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // GET: /weatherforecast/{id}
        [HttpGet("{id}")]
        public ActionResult<WeatherForecast> GetById(int id)
        {
            if (id < 1 || id > 5)
                return NotFound("Forecast not found");

            var forecast = new WeatherForecast
            {
                Date = DateTime.Now.AddDays(id).ToString("yyyy-MM-dd"),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };

            return Ok(forecast);
        }

        // POST: /weatherforecast
        [HttpPost]
        public ActionResult<WeatherForecast> Create([FromBody] WeatherForecast forecast)
        {
            _logger.LogInformation("Received forecast for {Date}", forecast.Date);
            return CreatedAtAction(nameof(GetById), new { id = 1 }, forecast); // giả định id = 1
        }
    }
}
