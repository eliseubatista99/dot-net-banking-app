using DotNetBankingAppApi.Data;
using DotNetBankingAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DotNetBankingAppApi.Controllers.GetInbox;

public class GetInboxMessageGroup
{
    public required DateTime DateTime { get; set; }
    public required List<MessageDTO> Messages { get; set; }

}

public class GetInboxInput
{
    public required string UserName { get; set; }
}

public class GetInboxOutput
{
    public required List<GetInboxMessageGroup> GroupedMessages { get; set; }
}

[Route("GetInbox")]
[ApiController]
public class GetInboxController : DotNetBankingAppController
{
    public GetInboxController(DatabaseContext context, IConfiguration configs) : base(context, configs)
    {

    }


    /// <summary>
    /// Get the messages of a specific user
    /// </summary>
    /// <param name="username" example="user"></param>
    /// <returns>List of messages grouped by date</returns>
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]

    public async Task<ActionResult<ApiResponse<GetInboxOutput>>> GetInbox(GetInboxInput input)
    {
        ApiResponse<GetInboxOutput> response = new ApiResponse<GetInboxOutput>();

        var messages = await MessagesData.GetMessagesOfUser(_context, input.UserName);

        var groupedMessages = new List<GetInboxMessageGroup>();

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
                groupedMessages.Add(new GetInboxMessageGroup { DateTime = messages[i].Date, Messages = new List<MessageDTO>([messages[i]]) });
            }
        }

        response.SetData(new GetInboxOutput
        {
            GroupedMessages = groupedMessages
        });

        return response;

    }

    private int GetGroupIndexForDate(List<GetInboxMessageGroup> messages, DateTime date)
    {
        return messages.FindIndex((m) =>
        {
            var messageDateText = m.DateTime.ToString("MM/dd/yyyy");
            var comparingDateText = date.ToString("MM/dd/yyyy");
            return messageDateText == comparingDateText;
        });
    }
}