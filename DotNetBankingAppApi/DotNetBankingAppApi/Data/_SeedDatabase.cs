using BankingAppApi.Models.User;
using DotNetBankingAppApi.Models.Message;
using Microsoft.EntityFrameworkCore;

namespace BankingAppApi.Data
{
    public class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DatabaseContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DatabaseContext>>()))
            {
                if (context.Users.Any() || context.Messages.Any())
                {
                    return;   // DB has been seeded
                }


                SeedUsers(context);
                SeedMessages(context);

                context.SaveChanges();
            }
        }

        public static void SeedUsers(DatabaseContext context)
        {
            context.Users.AddRange(
                     new User
                     {
                         UserName = "user1",
                         Password = "pass1",
                         PhoneNumber = "911111111"
                     },
                      new User
                      {
                          UserName = "user2",
                          Password = "pass2",
                          PhoneNumber = "922222222"

                      }
                 );
        }

        public static void SeedMessages(DatabaseContext context)
        {
            context.Messages.AddRange(
                     new Message
                     {
                         Id = "user1_12345",
                         UserName = "user1",
                         Date = new DateTime(2024, 04, 11, 19, 07, 59),
                         Subject = "Test message subject",
                         Content = "Test message content",
                     },
                      new Message
                      {
                          Id = "user1_6789",
                          UserName = "user1",
                          Date = new DateTime(2024, 04, 11, 19, 07, 59),
                          Subject = "Test message subject",
                          Content = "Test message content",

                      }
                 );
        }
    }
}
