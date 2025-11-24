using System.Text.Json.Serialization;
using Weatherly.Api.Enums;

namespace Weatherly.Api.Dtos.WeatherReturn
{
    /// <summary>
    /// All information for weather forecast
    /// </summary>
    /// <param name="Temperature"></param>
    /// <param name="DateTime"></param>
    /// <param name="Precipitation"></param>
    /// <param name="Weather"></param>
    public record WeatherForecastDto(
        float Temperature,
        DateTime Datetime,
        int Precipitation,
        [property: JsonConverter(typeof(JsonStringEnumConverter))] Weather Weather
    );
}
