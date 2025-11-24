using LanguageExt;
using Weatherly.Api.DomainPseudo.Models;

namespace Weatherly.Api.Dtos.User.UserAuth
{
    /// <summary>
    /// Incoming data to create/register user account
    /// </summary>
    /// <param name="Username"></param>
    /// <param name="Password"></param>
    /// <param name="Firstname"></param>
    /// <param name="Lastname"></param>
    /// <param name="Location"></param>
    public record CreateUserDto(
        string Username,
        string Password,
        string Firstname,
        string Lastname,
        string Location
    )
    {
        public UserDetails ToUserDetails(int id, Option<string> tokenOption)
        {
            return new UserDetails(
                Id: id,
                Username: Username,
                Password: Password,
                Firstname: Firstname,
                Lastname: Lastname,
                Location: Location,
                Token: tokenOption.Match(Some: token => token, None: () => "defaultToken")
            );
        }
    };
}
