// Ignore Spelling: App Api

using BankingAppApi.Data;
using BankingAppApi.Helpers;
using BankingAppApi.Models.User;
using DotNetBankingAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingAppApi.Controllers
{
    public class ServiceSignUpInput
    {
        public string username { get; set; }
        public string phoneNumber { get; set; }
        public string password { get; set; }
    }

    public class ServiceSignUpOutput
    {
        public UserDTO user { get; set; }
        public string token { get; set; }
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

            var existingUser = await UsersData.GetUser(_context, input.username);

            if (existingUser != null)
            {
                response.SetError("Username is aleady taken");
                return response;
            }

            var newUser = await UsersData.CreateUser(_context, new UserDTO
            {
                UserName = input.username,
                PhoneNumber = input.phoneNumber
            }, input.password);

            var authKey = _configs.GetSection("AuthKey")?.Value;

            var token = AuthHelper.GenerateToken(authKey, newUser.UserName);

            response.SetData(new ServiceSignUpOutput
            {
                user = newUser,
                token = token,
            });

            return response;
        }


    }
}
