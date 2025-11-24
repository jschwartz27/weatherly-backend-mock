using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using Weatherly.Api.Dtos.WeatherReturn;
using Weatherly.Api.Enums;

namespace Weatherly.Api.Controllers;

[ApiController]
[Route("api/v1/weather")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Get Weather Forecast
    /// </summary>
    /// <param name="location"></param>
    /// <param name="timespan"></param>
    /// <returns></returns>
    [HttpGet("forecast")]
    [Produces("application/json")]
    public async Task<ActionResult<IEnumerable<WeatherForecastDto>>> GetForecast(
        string location = "Berlin",
        TimeInterval timespan = TimeInterval.Day
    )
    {
        await Task.Delay(TimeSpan.FromSeconds(3));
        var datetime = DateTime.Now;

        return location == "Leipzig"
            ? StatusCode(500, $"[Internal Server Error] Failed to find forecast for: {location}!")
            : Ok(
                Enumerable
                    .Range(1, timespan == TimeInterval.Day ? 12 : 7)
                    .Select(
                        index =>
                            new WeatherForecastDto(
                                Temperature: -20 + (float)(new Random().NextDouble() * (40 - -20)),
                                Datetime: timespan == TimeInterval.Day
                                    ? datetime.AddHours(index)
                                    : datetime.AddDays(index),
                                Precipitation: 25,
                                Weather: Weather.Snowy
                            )
                    )
            );
    }

    /// <summary>
    /// Get Weather Forecast Description
    /// For testing: delay response by 5 seconds
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    [HttpGet("description")]
    [Produces("application/json")]
    public async Task<string> GetForecastDescription(string location)
    {
        await Task.Delay(TimeSpan.FromSeconds(5));
        return $"Weather for: {location}. Nice weather today. This is coming from the backend";
    }
}
