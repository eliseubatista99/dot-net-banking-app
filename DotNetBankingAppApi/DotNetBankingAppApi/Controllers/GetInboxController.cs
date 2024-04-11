using BankingAppApi.Data;
using DotNetBankingAppApi.Models;
using DotNetBankingAppApi.Models.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BankingAppApi.Controllers
{
    public class ServiceGetInboxInput
    {
        public required string username { get; set; }
    }

    public class ServiceGetInboxOutput
    {
        public required List<MessageDTO> messages { get; set; }
    }

    [Route("GetInbox")]
    [ApiController]
    public class GetInboxController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configs;

        public GetInboxController(DatabaseContext context, IConfiguration configs)
        {
            _context = context;
            _configs = configs;
        }


        /// <summary>
        /// Get the messages of a specific user
        /// </summary>
        /// <param name="username" example="user"></param>
        /// <returns>User data and token</returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [AllowAnonymous]

        public async Task<ActionResult<ApiResponse<ServiceGetInboxOutput>>> GetInbox(ServiceGetInboxInput input)
        {
            ApiResponse<ServiceGetInboxOutput> response = new ApiResponse<ServiceGetInboxOutput>();

            var messages = await MessagesData.GetMessagesOfUser(_context, input.username);

            response.SetData(new ServiceGetInboxOutput
            {
                messages = messages
            });

            return response;

        }
    }
}