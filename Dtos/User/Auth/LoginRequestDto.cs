namespace Weatherly.Api.Dtos.User.UserAuth
{
    /// <summary>
    /// details required for user login
    /// </summary>
    /// <param name="Username"></param>
    /// <param name="Password"></param>
    public record LoginRequestDto(string Username, string Password);
}
