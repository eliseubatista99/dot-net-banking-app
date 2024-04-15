using DotNetBankingAppApi.Data;
using DotNetBankingAppApi.Helpers;
using DotNetBankingAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DotNetBankingAppApi.Controllers.SignIn;

public class SignInInput
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
}

public class SignInOutput
{
    public required UserDTO User { get; set; }
    public required string Token { get; set; }
}

[Route("SignIn")]
[ApiController]
public class SignInController : DotNetBankingAppController
{
    public SignInController(DatabaseContext context, IConfiguration configs) : base(context, configs)
    {

    }


    /// <summary>
    /// Sign In with userName and password
    /// </summary>
    /// <param name="username" example="user"></param>
    /// <param name="password" example="pass"></param>
    /// <returns>User data and token</returns>
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    [AllowAnonymous]

    public async Task<ActionResult<ApiResponse<SignInOutput>>> SignIn(SignInInput input)
    {
        ApiResponse<SignInOutput> response = new ApiResponse<SignInOutput>();

        var user = await UsersData.GetUserWithPassword(_context, input.UserName, input.Password);

        if (user == null)
        {
            response.SetError("UserName or password invalid");

            return response;
        }

        var authKey = _configs.GetSection("AuthKey")?.Value ?? "";

        var token = AuthHelper.GenerateToken(authKey, user.UserName);

        if (token == null)
        {
            response.SetError("Failed to generate authentication token");

            return response;
        }

        response.SetData(new SignInOutput
        {
            User = user,
            Token = token,
        });

        return response;

    }
}