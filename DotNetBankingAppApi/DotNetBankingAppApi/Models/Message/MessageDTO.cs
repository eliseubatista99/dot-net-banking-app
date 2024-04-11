namespace DotNetBankingAppApi.Models.Message
{
    public class MessageDTO
    {
        public string Subject { get; set; } = "";
        public string Content { get; set; } = "";
        public DateTime Date { get; set; } = DateTime.Now;

        public static MessageDTO FromMessage(Message message)
        {
            return new MessageDTO { Subject = message.Subject, Content = message.Content, Date = message.Date };
        }

        public static Message ToMessage(MessageDTO messageDTO)
        {
            return new Message { Subject = messageDTO.Subject, Content = messageDTO.Content, Date = messageDTO.Date };
        }
    }
}
