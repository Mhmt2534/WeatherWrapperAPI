using Microsoft.AspNetCore.Mvc;
using WeatherWrapperAPI.Services;

namespace WeatherWrapperAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherService _weatherService;
        public WeatherForecastController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }


        [HttpGet]
        public async Task<IActionResult> GetWeather(string city) {

            string result = await _weatherService.GetWeatherAsync(city);

            if (result.Contains("Unauthorized"))
                return StatusCode(401,result);

            return Ok(result);
        }


    }
}
