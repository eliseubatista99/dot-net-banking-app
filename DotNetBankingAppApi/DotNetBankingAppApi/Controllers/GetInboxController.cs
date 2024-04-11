using BankingAppApi.Data;
using DotNetBankingAppApi.Models;
using DotNetBankingAppApi.Models.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BankingAppApi.Controllers
{
    public class ServiceGetInboxMessageGroup
    {
        public required DateTime dateTime { get; set; }
        public required List<MessageDTO> messages { get; set; }

    }

    public class ServiceGetInboxInput
    {
        public required string username { get; set; }
    }

    public class ServiceGetInboxOutput
    {
        public required List<ServiceGetInboxMessageGroup> groupedMessages { get; set; }
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

            var groupedMessages = new List<ServiceGetInboxMessageGroup>();

            for (int i = 0; i < messages.Count; i++)
            {
                var dateText = messages[i].Date.ToString("MM/dd/yyyy");

                var groupIndexForDate = GetGroupIndexForDate(groupedMessages, messages[i].Date);

                if (groupIndexForDate != -1)
                {
                    groupedMessages[groupIndexForDate].messages.Add(messages[i]);
                }
                else
                {
                    groupedMessages.Add(new ServiceGetInboxMessageGroup { dateTime = messages[i].Date, messages = new List<MessageDTO>([messages[i]]) });
                }
            }

            response.SetData(new ServiceGetInboxOutput
            {
                groupedMessages = groupedMessages
            });

            return response;

        }

        private int GetGroupIndexForDate(List<ServiceGetInboxMessageGroup> messages, DateTime date)
        {
            return messages.FindIndex((m) =>
            {
                var messageDateText = m.dateTime.ToString("MM/dd/yyyy");
                var comparingDateText = date.ToString("MM/dd/yyyy");
                return messageDateText == comparingDateText;
            });
        }
    }
}