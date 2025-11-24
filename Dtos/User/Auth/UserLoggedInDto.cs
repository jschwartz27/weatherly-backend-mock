namespace Weatherly.Api.Dtos.User.UserAuth
{
    /// <summary>
    /// Returned to frontend for user info
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Username"></param>
    /// <param name="Firstname"></param>
    /// <param name="Lastname"></param>
    /// <param name="Location"></param>
    /// <param name="Token"></param>
    public record UserLoggedInDto(
        int Id,
        string Username,
        string Firstname,
        string Lastname,
        string Location,
        string Token
    );
}
