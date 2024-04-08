using BankingAppApi.Data;
using BankingAppApi.Helpers;
using BankingAppApi.Models.User;
using DotNetBankingAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BankingAppApi.Controllers
{
    public class ServiceSignInInput
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class ServiceSignInOutput
    {
        public UserDTO user { get; set; }
        public string token { get; set; }
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

            var user = await UsersData.GetUserWithPassword(_context, input.username, input.password);

            if (user == null)
            {
                response.SetError("User does not exists");

                return response;
            }

            var authKey = _configs.GetSection("AuthKey")?.Value;

            var token = AuthHelper.GenerateToken(authKey, user.UserName);

            response.SetData(new ServiceSignInOutput
            {
                user = user,
                token = token,
            });

            return response;

        }
    }
}