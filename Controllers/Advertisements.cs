using Microsoft.AspNetCore.Mvc;
using Weatherly.Api.Dtos.WeatherReturn;
using Weatherly.Api.InfrastructurePseudo;

namespace Weatherly.Api.Controllers;

[ApiController]
[Route("api/v1/advertisements")]
public class AdvertisementsController : ControllerBase
{
    /// <summary>
    /// Get Advertisement by Location
    /// </summary>
    /// <param name="location">The city or area for the advertisement</param>
    [HttpGet]
    [Produces("application/json")]
    public ActionResult<AdvertisementDto> GetAdvertisementByLocation(string location)
    {
        var displayType = new Random().Next(2) == 0;
        return Ok(
            new AdvertisementDto(
                Location: location,
                Company: $"Company In {location} (via Backend)",
                Image_url: new AdvertisementDatabase().SelectRandomAdvertisement(displayType),
                Display_type: displayType // GetRandomEnumValue<AdvertisementType>()
            )
        );
    }
}
