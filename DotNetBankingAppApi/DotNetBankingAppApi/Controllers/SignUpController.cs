// Ignore Spelling: App Api

using DotNetBankingAppApi.Data;
using DotNetBankingAppApi.Helpers;
using DotNetBankingAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBankingAppApi.Controllers;

public class ServiceSignUpInput
{
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}

public class ServiceSignUpOutput
{
    public UserDTO User { get; set; }
    public string Token { get; set; }
}

[Route("SignUp")]
[ApiController]
public class SignUpController : ControllerBase
{
    private readonly DatabaseContext _context;
    private readonly IConfiguration _configs;

    public SignUpController(DatabaseContext context, IConfiguration configs)
    {
        _context = context;
        _configs = configs;
    }


    /// <summary>
    /// Sign Up with username, phoneNumber and password
    /// </summary>
    /// <param name="username" example="user"></param>
    /// <param name="phoneNumber" example="911111111"></param>
    /// <param name="password" example="pass"></param>
    /// <returns>User data and token</returns>
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    [AllowAnonymous]

    public async Task<ActionResult<ApiResponse<ServiceSignUpOutput>>> SignUp(ServiceSignUpInput input)
    {
        ApiResponse<ServiceSignUpOutput> response = new ApiResponse<ServiceSignUpOutput>();

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

        var authKey = _configs.GetSection("AuthKey")?.Value;

        var token = AuthHelper.GenerateToken(authKey, newUser.UserName);

        response.SetData(new ServiceSignUpOutput
        {
            User = newUser,
            Token = token,
        });

        return response;
    }


}