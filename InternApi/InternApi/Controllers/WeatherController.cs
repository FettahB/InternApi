using InternApi.Database.Context;
using InternApi.Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InternApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        MyDbContext _dbContext;

        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger, MyDbContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<Weather>> GetWeatherData()
        {
            var weatherData = _dbContext.Weather.ToList();
            return Ok(weatherData);
        }
    }
}
