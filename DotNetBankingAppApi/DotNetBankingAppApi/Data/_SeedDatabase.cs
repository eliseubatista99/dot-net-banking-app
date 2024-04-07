using BankingAppApi.Models.User;
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
                // Look for any movies.
               if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }


                SeedUsers(context);
                //SeedPolicies(context);
                //SeedSinisters(context);

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
    }
}
