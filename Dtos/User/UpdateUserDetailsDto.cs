namespace Weatherly.Api.Dtos.User
{
    /// <summary>
    /// Incoming data to update user details
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Username"></param>
    /// <param name="FirstName"></param>
    /// <param name="LastName"></param>
    /// <param name="Location"></param>
    public record UpdateUserDetailsDto(
        int Id,
        string Username,
        string FirstName,
        string LastName,
        string Location
    );
}
