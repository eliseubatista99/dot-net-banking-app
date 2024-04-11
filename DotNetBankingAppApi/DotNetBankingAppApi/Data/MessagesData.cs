using DotNetBankingAppApi.Models.Message;
using Microsoft.EntityFrameworkCore;

namespace BankingAppApi.Data
{
    public class MessagesData
    {
        public static async Task<List<MessageDTO>> GetMessagesOfUser(DatabaseContext context, string username)
        {
            var messages = await context.Messages.Where((m) => m.UserName == username).ToListAsync();

            if (messages == null)
            {
                return new List<MessageDTO>();
            }

            return messages.Select((m) => MessageDTO.FromMessage(m)).ToList();
        }

        public static async Task<MessageDTO> AddMessageToUser(DatabaseContext context, MessageDTO messageDTO, string username)
        {
            var message = MessageDTO.ToMessage(messageDTO);

            message.UserName = username;
            message.Id = username + "_" + DateTime.Now;
            message.Date = DateTime.Now;

            context.Messages.Add(message);
            await context.SaveChangesAsync();

            return MessageDTO.FromMessage(message);
        }
    }
}