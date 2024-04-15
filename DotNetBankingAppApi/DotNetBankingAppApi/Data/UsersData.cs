using DotNetBankingAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetBankingAppApi.Data;

public class UsersData
{
    public static async Task<List<UserDTO>> GetUsers(DatabaseContext context)
    {
        var result = await context.Users.ToListAsync();

        return result.Select((item) => UserDTO.ToDTO(item)).ToList();
    }

    public static async Task<UserDTO?> GetUser(DatabaseContext context, string UserName)
    {
        var result = await context.Users.FindAsync(UserName);

        if (result == null)
        {
            return null;
        }

        return UserDTO.ToDTO(result);
    }

    public static async Task<UserDTO?> GetUserWithPassword(DatabaseContext context, string UserName, string password)
    {
        var result = await context.Users.FindAsync(UserName);

        if (result == null)
        {
            return null;
        }

        if (password != result.Password)
        {
            return null;
        }

        return UserDTO.ToDTO(result);
    }

    public static async Task<UserDTO> CreateUser(DatabaseContext context, UserDTO userDTO, string password)
    {
        var result = UserDTO.FromDTO(userDTO);
        result.Password = password;

        context.Users.Add(result);
        await context.SaveChangesAsync();

        return userDTO;
    }
}