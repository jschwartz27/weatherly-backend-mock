using Weatherly.Api.DomainPseudo.Models;

namespace Weatherly.Api.MockBackend
{
    /// <summary>
    /// In memory storage for "user accounts"
    /// </summary>
    public static class ExistingUsers
    {
        public static List<UserDetails> Users =
            new()
            {
                new UserDetails(
                    Id: 1,
                    Username: "Darth",
                    Password: "1234",
                    Firstname: "Anakin",
                    Lastname: "Skywalker",
                    Location: "Munich",
                    Token: "Token"
                )
            };
    }
}
