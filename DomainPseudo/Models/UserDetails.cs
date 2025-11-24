using Weatherly.Api.Dtos.User.UserAuth;

namespace Weatherly.Api.DomainPseudo.Models
{
    /// <summary>
    /// Stores all relevant details for user
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Username"></param>
    /// <param name="Password"></param>
    /// <param name="Firstname"></param>
    /// <param name="Lastname"></param>
    /// <param name="Location"></param>
    /// <param name="Token"></param>
    public record UserDetails(
        int Id,
        string Username,
        string Password,
        string Firstname,
        string Lastname,
        string Location,
        string Token
    )
    {
        /// <summary>
        /// Exposes user info to frontend without Password
        /// </summary>
        /// <returns></returns>
        public UserLoggedInDto ToUserLoggedInDto()
        {
            return new UserLoggedInDto(
                Id: Id,
                Username: Username,
                Firstname: Firstname,
                Lastname: Lastname,
                Location: Location,
                Token: Token
            );
        }
    };
}
