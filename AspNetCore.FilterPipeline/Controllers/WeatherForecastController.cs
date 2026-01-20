using AspNetCore.FilterPipeline;
using AspNetCore.FilterPipeline.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.FilterPipeline.Controllers
{
    
    [ServiceFilter(typeof(CustomActionFilter))]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("TestFilter")]
        public IActionResult TestFilter(string? name, string? surname)//burda da quety params var 
        {
            return Ok(new { Name = name, Surname = surname });
        }
    }
}