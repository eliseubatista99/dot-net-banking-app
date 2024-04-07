using System.ComponentModel.DataAnnotations;

namespace BankingAppApi.Models.User
{
    public class User
    {
        [Key, DataType(DataType.EmailAddress)]
        public string UserName { get; set; } = "";

        [Required, MinLength(9), DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = "";

        [Required, MinLength(8), RegularExpression("^[^\\s\\,]+$")]
        public string Password { get; set; } = "";

       
    }
}
