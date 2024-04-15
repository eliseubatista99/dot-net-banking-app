using DotNetBankingAppApi.Data;
using DotNetBankingAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DotNetBankingAppApi.Controllers;

public class ServiceGetInboxMessageGroup
{
    public required DateTime DateTime { get; set; }
    public required List<MessageDTO> Messages { get; set; }

}

public class ServiceGetInboxInput
{
    public required string UserName { get; set; }
}

public class ServiceGetInboxOutput
{
    public required List<ServiceGetInboxMessageGroup> GroupedMessages { get; set; }
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
    /// <returns>List of messages grouped by date</returns>
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]

    public async Task<ActionResult<ApiResponse<ServiceGetInboxOutput>>> GetInbox(ServiceGetInboxInput input)
    {
        ApiResponse<ServiceGetInboxOutput> response = new ApiResponse<ServiceGetInboxOutput>();

        var messages = await MessagesData.GetMessagesOfUser(_context, input.UserName);

        var groupedMessages = new List<ServiceGetInboxMessageGroup>();

        for (int i = 0; i < messages.Count; i++)
        {
            var dateText = messages[i].Date.ToString("MM/dd/yyyy");

            var groupIndexForDate = GetGroupIndexForDate(groupedMessages, messages[i].Date);

            if (groupIndexForDate != -1)
            {
                groupedMessages[groupIndexForDate].Messages.Add(messages[i]);
            }
            else
            {
                groupedMessages.Add(new ServiceGetInboxMessageGroup { DateTime = messages[i].Date, Messages = new List<MessageDTO>([messages[i]]) });
            }
        }

        response.SetData(new ServiceGetInboxOutput
        {
            GroupedMessages = groupedMessages
        });

        return response;

    }

    private int GetGroupIndexForDate(List<ServiceGetInboxMessageGroup> messages, DateTime date)
    {
        return messages.FindIndex((m) =>
        {
            var messageDateText = m.DateTime.ToString("MM/dd/yyyy");
            var comparingDateText = date.ToString("MM/dd/yyyy");
            return messageDateText == comparingDateText;
        });
    }
}