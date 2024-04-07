// Ignore Spelling: App Api

using BankingAppApi.Data;
using BankingAppApi.Helpers;
using BankingAppApi.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingAppApi.Controllers
{
    public class ServiceRegisterInput
    {
        public string username { get; set; }
        public string phoneNumber { get; set; }
        public string password { get; set; }
    }

    public class ServiceRegisterOutput
    {
        public UserDTO user { get; set; }
        public string token { get; set; }
    }

    [Route("Register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configs;

        public RegisterController(DatabaseContext context, IConfiguration configs)
        {
            _context = context;
            _configs = configs;
        }


        /// <summary>
        /// Register with username, phoneNumber and password
        /// </summary>
        /// <param name="username" example="user"></param>
        /// <param name="phoneNumber" example="911111111"></param>
        /// <param name="password" example="pass"></param>
        /// <returns>User data and token</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [AllowAnonymous]

        public async Task<ActionResult<ServiceRegisterOutput>> Register(ServiceRegisterInput input)
        {
            var existingUser = await UsersData.GetUser(_context, input.username);

            if (existingUser != null)
            {
                return BadRequest("User already exists");
            }

            var newUser = await UsersData.CreateUser(_context, new UserDTO
            {
                UserName = input.username,
                PhoneNumber = input.phoneNumber
            }, input.password);

            var authKey = _configs.GetSection("AuthKey")?.Value;

            var token = AuthHelper.GenerateToken(authKey, newUser.UserName);

            ServiceRegisterOutput response = new ServiceRegisterOutput();

            response.user = newUser;
            response.token = token;

            return response;
        }


    }
}
