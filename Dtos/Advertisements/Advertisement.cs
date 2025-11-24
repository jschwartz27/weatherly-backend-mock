namespace Weatherly.Api.Dtos.WeatherReturn
{
    /// <summary>
    /// Advertisement Dto
    /// </summary>
    /// <param name="Location"></param>
    /// <param name="Company"></param>
    /// <param name="Image_url"></param>
    /// <param name="Display_type"></param>
    public record AdvertisementDto(
        string Location,
        string Company,
        string Image_url,
        // [property: JsonConverter(typeof(JsonStringEnumConverter))] AdvertisementType Type
        bool Display_type
    );
}
