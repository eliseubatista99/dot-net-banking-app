using DotNetBankingAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetBankingAppApi.Data;

public class MessagesData
{
    public static async Task<List<MessageDTO>> GetMessagesOfUser(DatabaseContext context, string UserName)
    {
        var result = await context.Messages.Where((item) => item.UserName == UserName).ToListAsync();

        if (result == null)
        {
            return new List<MessageDTO>();
        }

        return result.Select((item) => MessageDTO.ToDTO(item)).ToList();
    }

    public static async Task<MessageDTO> AddMessageToUser(DatabaseContext context, MessageDTO data, string UserName)
    {
        var dataToAdd = MessageDTO.FromDTO(data);

        dataToAdd.UserName = UserName;
        dataToAdd.Id = UserName + "_" + DateTime.Now;
        dataToAdd.Date = DateTime.Now;

        context.Messages.Add(dataToAdd);
        await context.SaveChangesAsync();

        return MessageDTO.ToDTO(dataToAdd);
    }
}