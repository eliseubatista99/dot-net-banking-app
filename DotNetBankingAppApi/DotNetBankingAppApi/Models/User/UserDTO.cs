namespace DotNetBankingAppApi.Models;

public class UserDTO
{
    public string UserName { get; set; } = "";
    public string PhoneNumber { get; set; } = "";

    public static UserDTO ToDTO(User data)
    {
        return new UserDTO { UserName = data.UserName, PhoneNumber = data.PhoneNumber };
    }

    public static User FromDTO(UserDTO data)
    {
        return new User { UserName = data.UserName, PhoneNumber = data.PhoneNumber };
    }
}