using System.Collections.Immutable;

namespace Weatherly.Api.InfrastructurePseudo
{
    public record AdvertisementDatabase
    {
        private readonly static string _url = "https://cdn.gdelivr.net/static/divein-ads/";

        private ImmutableList<string> Horizontal { get; init; } =
            ImmutableList.Create(
                _url + "h_coffee.png",
                _url + "h_coffee2.png",
                _url + "h_leipzig.png",
                _url + "h_planet_azure.png",
                _url + "h_takeout.png",
                _url + "h_takeout2.png"
            );

        private ImmutableList<string> Vertical { get; init; } =
            ImmutableList.Create(
                _url + "v_coffee.png",
                _url + "v_coffee2.png",
                _url + "v_coffee3.png",
                _url + "v_leipzig.png",
                _url + "v_planet_azure.png",
                _url + "v_planet_azure2.png",
                _url + "v_planet_azure3.png",
                _url + "v_takeout.png",
                _url + "v_takeout2.png",
                _url + "v_takeout3.png"
            );

        /// <summary>
        /// Return random ad given the display type
        /// </summary>
        /// <param name="displayType"></param>
        /// <returns></returns>
        public string SelectRandomAdvertisement(bool displayType)
        {
            Random random = new();
            return displayType
                ? Horizontal[random.Next(Horizontal.Count)]
                : Vertical[random.Next(Vertical.Count)];
        }
    }
}
