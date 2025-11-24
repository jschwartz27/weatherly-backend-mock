using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using Weatherly.Api.MockBackend;
using Weatherly.Api.DomainPseudo.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Weatherly.Api.Dtos.User.UserAuth;
using Weatherly.Api.Dtos.User;

namespace Weatherly.Api.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Authenticate User
    /// </summary>
    /// <param name="request"></param>
    [HttpPost("authenticate")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(UserLoggedInDto), 200)]
    [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
    public async Task<IActionResult> AuthenticateUserAsync([FromBody] LoginRequestDto request)
    {
        return await (
            (Option<UserDetails>)
                ExistingUsers.Users.FirstOrDefault(
                    u => u.Username == request.Username && u.Password == request.Password
                )
        ).Match(
            Some: user => Task.FromResult<IActionResult>(Ok(user.ToUserLoggedInDto())),
            None: async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(4));
                return Unauthorized("Invalid username or password") as IActionResult;
            }
        );
    }

    /// <summary>
    /// Create New User
    /// </summary>
    /// <param name="createUserInfo"></param>
    /// <returns></returns>
    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(typeof(UserLoggedInDto), 201)]
    [ProducesResponseType(typeof(ObjectResult), 500)]
    public IActionResult CreateUser([FromBody] CreateUserDto createUserInfo)
    {
        return ExistingUsers.Users.Any(u => u.Username == createUserInfo.Username)
            ? StatusCode(
                500,
                $"[Internal Server Error] Username: {createUserInfo.Username}, error creating!"
            )
            : Ok(AddAndConvertToUserLoggedInDto(createUserInfo));
    }

    private static UserLoggedInDto AddAndConvertToUserLoggedInDto(CreateUserDto createUserInfo)
    {
        var userDetails = createUserInfo.ToUserDetails(
            ExistingUsers.Users.Max(r => r.Id) + 1,
            Guid.NewGuid().ToString()
        );
        ExistingUsers.Users.Add(userDetails);
        return userDetails.ToUserLoggedInDto();
    }

    /// <summary>
    /// Update User Details
    /// For testing: if username == "test" returns 500
    /// </summary>
    /// <param name="updateUserdetails"></param>
    /// <returns></returns>
    [HttpPut]
    [Produces("application/json")]
    [ProducesResponseType(typeof(OkResult), 200)]
    [ProducesResponseType(typeof(BadRequest), 400)]
    public IActionResult UpdateUserDetails([FromBody] UpdateUserDetailsDto updateUserdetails)
    {
        var index = ExistingUsers.Users.FindIndex(
            userDetails => userDetails.Id == updateUserdetails.Id
        );
        return index != -1 && updateUserdetails.Username != "test" // For error testing
            ? Ok(
                ExistingUsers.Users[index] = ExistingUsers.Users[index] with
                {
                    Username = updateUserdetails.Username,
                    Firstname = updateUserdetails.FirstName,
                    Lastname = updateUserdetails.LastName,
                    Location = updateUserdetails.Location
                }
            )
            : BadRequest($"[Bad Request] User Id: {updateUserdetails.Id}, not found!");
    }
}
