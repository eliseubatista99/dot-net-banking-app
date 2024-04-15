using DotNetBankingAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetBankingAppApi.Data;

public class UsersData
{
    public static async Task<List<UserDTO>> GetUsers(DatabaseContext context)
    {
        var usersInDB = await context.Users.ToListAsync();
        List<UserDTO> users = new List<UserDTO>();

        foreach (var user in usersInDB)
        {
            var userDTO = UserDTO.FromUser(user);
            users.Add(userDTO);
        }

        return users;
    }

    public static async Task<UserDTO?> GetUser(DatabaseContext context, string username)
    {
        var user = await context.Users.FindAsync(username);

        if (user == null)
        {
            return null;
        }

        return UserDTO.FromUser(user);
    }

    public static async Task<UserDTO?> GetUserWithPassword(DatabaseContext context, string email, string password)
    {
        var user = await context.Users.FindAsync(email);

        if (user == null)
        {
            return null;
        }

        if (password != user.Password)
        {
            return null;
        }

        return UserDTO.FromUser(user);
    }

    public static async Task<UserDTO> CreateUser(DatabaseContext context, UserDTO userDTO, string password)
    {
        var user = UserDTO.ToUser(userDTO);
        user.Password = password;

        context.Users.Add(user);
        await context.SaveChangesAsync();

        return userDTO;
    }
}