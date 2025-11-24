using System.Text.Json.Serialization;
using Weatherly.Api.Enums;

namespace Weatherly.Api.Dtos.WeatherRequest
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="Location"></param>
    /// <param name="TimeSpan"></param>
    public record WeatherRequestDto(
        string Location,
        [property: JsonConverter(typeof(JsonStringEnumConverter))] TimeInterval TimeSpan
    );
}
