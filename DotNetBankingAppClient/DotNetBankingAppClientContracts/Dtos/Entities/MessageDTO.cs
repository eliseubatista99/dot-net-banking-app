namespace DotNetBankingAppClientContracts.Models;

public class MessageDTOGroup
{
    public required DateTime dateTime { get; set; }
    public required List<MessageDTO> messages { get; set; }

}

public class MessageDTO
{
    public string Subject { get; set; } = "";
    public string Content { get; set; } = "";
    public DateTime Date { get; set; } = DateTime.Now;

    public override string ToString()
    {
        return "Message: {\nSubject: " + Subject + ",\nContent: " + Content + "\nDate: " + Date.ToString() + "\n}";
    }
}