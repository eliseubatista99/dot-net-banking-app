using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BankingAppApi.Helpers
{
    public class AuthHelper
    {
        private static string? GenerateToken(string authKey, string username, string? role, double? timeout)
        {
            if (authKey == null || username == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(authKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("user", username),
                    new Claim("role", role ?? "client")
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static string? GenerateToken(string authKey, string username, string? role)
        {
            return GenerateToken(authKey, username, role, 1);
        }

        public static string? GenerateToken(string authKey, string username, double? timeout)
        {
            return GenerateToken(authKey, username, "client", timeout);
        }

        public static string? GenerateToken(string authKey, string username)
        {
            return GenerateToken(authKey, username, "client", 1);
        }
    }
}
