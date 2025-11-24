namespace Weatherly.Api.Enums
{
    /// <summary>
    /// Time interval of hourly (day) or daily (week)
    /// </summary>
    public enum TimeInterval
    {
        Day,
        Week
    }

    /// <summary>
    /// Types of weather
    /// </summary>
    public enum Weather
    {
        Snowy,
        Windy,
        ClearNight,
        CloudyNight,
        Sunny,
        ThunderStorm,
        Cloudy,
        PartiallyCloudy,
        Rainy
    }
}
