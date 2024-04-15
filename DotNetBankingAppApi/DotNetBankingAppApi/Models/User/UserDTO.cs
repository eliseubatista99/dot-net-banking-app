namespace DotNetBankingAppApi.Models;

public class UserDTO
{
    public string UserName { get; set; } = "";
    public string PhoneNumber { get; set; } = "";

    public static UserDTO FromUser(User user)
    {
        return new UserDTO { UserName = user.UserName, PhoneNumber = user.PhoneNumber };
    }

    public static User ToUser(UserDTO userDTO)
    {
        return new User { UserName = userDTO.UserName, PhoneNumber = userDTO.PhoneNumber };
    }
}