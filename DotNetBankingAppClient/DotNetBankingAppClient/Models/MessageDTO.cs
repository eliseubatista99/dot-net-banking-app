namespace DotNetBankingAppClient.Models
{
    public class MessageDTO
    {
        public string Subject { get; set; } = "";
        public string Content { get; set; } = "";
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
