using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using BankingAppApi.Data;
using BankingAppApi.Models.User;
using Microsoft.AspNetCore.Authentication;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Text.Json;
using BankingAppApi.Helpers;


namespace BankingAppApi.Controllers
{
    public class ServiceLoginInput
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class ServiceLoginOutput
    {
        public UserDTO user { get; set; }
        public string token { get; set; }
    }

    [Route("Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configs;

        public LoginController(DatabaseContext context, IConfiguration configs)
        {
            _context = context;
            _configs = configs;
        }


        /// <summary>
        /// Login with username and password
        /// </summary>
        /// <param name="username" example="user"></param>
        /// <param name="password" example="pass"></param>
        /// <returns>User data and token</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [AllowAnonymous]

        public async Task<ActionResult<ServiceLoginOutput>> Login(ServiceLoginInput input)
        {
            var user = await UsersData.GetUserWithPassword(_context, input.username, input.password);

            if (user == null)
            {
                return NotFound("Invalid user or password");
            }

            var authKey = _configs.GetSection("AuthKey")?.Value;

            var token = AuthHelper.GenerateToken(authKey, user.UserName);

            ServiceLoginOutput response = new ServiceLoginOutput();

            response.user = user;
            response.token = token;

            return response;
        }
    }
}