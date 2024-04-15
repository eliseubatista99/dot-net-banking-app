using System.ComponentModel.DataAnnotations;

namespace DotNetBankingAppApi.Models;

public class Message
{
    [Key]
    public string Id { get; set; } = "";
    [Required]
    public string UserName { get; set; } = "";
    [Required]
    public string Subject { get; set; } = "";
    [Required]
    public string Content { get; set; } = "";
    [Required, DataType(DataType.DateTime)]
    public DateTime Date { get; set; } = DateTime.Now;
}