namespace DotNetBankingAppApi.Models;

public class MessageDTO
{
    public string Subject { get; set; } = "";
    public string Content { get; set; } = "";
    public DateTime Date { get; set; } = DateTime.Now;

    public static MessageDTO ToDTO(Message data)
    {
        return new MessageDTO { Subject = data.Subject, Content = data.Content, Date = data.Date };
    }

    public static Message FromDTO(MessageDTO data)
    {
        return new Message { Subject = data.Subject, Content = data.Content, Date = data.Date };
    }
}