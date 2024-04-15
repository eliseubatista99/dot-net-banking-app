using DotNetBankingAppApi.Data;
using DotNetBankingAppApi.Helpers;
using DotNetBankingAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DotNetBankingAppApi.Controllers;

public class ServiceSignInInput
{
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class ServiceSignInOutput
{
    public UserDTO User { get; set; }
    public string Token { get; set; }
}

[Route("SignIn")]
[ApiController]
public class SignInController : ControllerBase
{
    private readonly DatabaseContext _context;
    private readonly IConfiguration _configs;

    public SignInController(DatabaseContext context, IConfiguration configs)
    {
        _context = context;
        _configs = configs;
    }


    /// <summary>
    /// Sign In with username and password
    /// </summary>
    /// <param name="username" example="user"></param>
    /// <param name="password" example="pass"></param>
    /// <returns>User data and token</returns>
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    [AllowAnonymous]

    public async Task<ActionResult<ApiResponse<ServiceSignInOutput>>> SignIn(ServiceSignInInput input)
    {
        ApiResponse<ServiceSignInOutput> response = new ApiResponse<ServiceSignInOutput>();

        var user = await UsersData.GetUserWithPassword(_context, input.UserName, input.Password);

        if (user == null)
        {
            response.SetError("Username or password invalid");

            return response;
        }

        var authKey = _configs.GetSection("AuthKey")?.Value;

        var token = AuthHelper.GenerateToken(authKey, user.UserName);

        response.SetData(new ServiceSignInOutput
        {
            User = user,
            Token = token,
        });

        return response;

    }
}