// Ignore Spelling: App Api

using DotNetBankingAppApi.Data;
using DotNetBankingAppApi.Helpers;
using DotNetBankingAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBankingAppApi.Controllers.SignUp;

public class SignUpInput
{
    public required string UserName { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Password { get; set; }
}

public class SignUpOutput
{
    public required UserDTO User { get; set; }
    public required string Token { get; set; }
}

[Route("SignUp")]
[ApiController]
public class SignUpController : DotNetBankingAppController
{
    public SignUpController(DatabaseContext context, IConfiguration configs) : base(context, configs)
    {

    }


    /// <summary>
    /// Sign Up with userName, phoneNumber and password
    /// </summary>
    /// <param name="username" example="user"></param>
    /// <param name="phoneNumber" example="911111111"></param>
    /// <param name="password" example="pass"></param>
    /// <returns>User data and token</returns>
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    [AllowAnonymous]

    public async Task<ActionResult<ApiResponse<SignUpOutput>>> SignUp(SignUpInput input)
    {
        ApiResponse<SignUpOutput> response = new ApiResponse<SignUpOutput>();

        var existingUser = await UsersData.GetUser(_context, input.UserName);

        if (existingUser != null)
        {
            response.SetError("Username is aleady taken");
            return response;
        }

        var newUser = await UsersData.CreateUser(_context, new UserDTO
        {
            UserName = input.UserName,
            PhoneNumber = input.PhoneNumber
        }, input.Password);

        var authKey = _configs.GetSection("AuthKey")?.Value ?? "";

        var token = AuthHelper.GenerateToken(authKey, newUser.UserName);

        if (token == null)
        {
            response.SetError("Failed to generate authentication token");

            return response;
        }

        response.SetData(new SignUpOutput
        {
            User = newUser,
            Token = token,
        });

        return response;
    }
}