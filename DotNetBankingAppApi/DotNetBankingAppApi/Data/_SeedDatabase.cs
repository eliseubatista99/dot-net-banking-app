using DotNetBankingAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetBankingAppApi.Data;

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
            SeedAccounts(context);
            SeedCards(context);

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
                     Id = "user1_11111",
                     UserName = "user1",
                     Date = new DateTime(2024, 04, 11, 19, 07, 59),
                     Subject = "Money transfered successfully",
                     Content = "You transfert to Contact1 was successfull",
                 },
                  new Message
                  {
                      Id = "user1_22222",
                      UserName = "user1",
                      Date = new DateTime(2024, 04, 11, 19, 08, 59),
                      Subject = "We were unable to send money",
                      Content = "You attempt to send money to Contact1 failed. If you still want to transfer, please try again",
                  },
                  new Message
                  {
                      Id = "user1_33333",
                      UserName = "user1",
                      Date = new DateTime(2024, 04, 11, 19, 10, 59),
                      Subject = "New login detected",
                      Content = "New login was detected on 22/01/2024 at 19:45",
                  },
                  new Message
                  {
                      Id = "user1_444444",
                      UserName = "user1",
                      Date = new DateTime(2024, 03, 11, 19, 8, 59),
                      Subject = "Keep saving with us",
                      Content = "Your saving earned you 472€ this year. Stick with us next year to improve your wealth.",
                  },
                  new Message
                  {
                      Id = "user1_55555",
                      UserName = "user1",
                      Date = new DateTime(2024, 02, 11, 19, 10, 59),
                      Subject = "Your account has a new card",
                      Content = "Card 1234 5678 9101 1121 was added to your acount",
                  },
                  new Message
                  {
                      Id = "user1_66666",
                      UserName = "user1",
                      Date = new DateTime(2024, 02, 11, 19, 3, 59),
                      Subject = "Welcome to DotNet Banking",
                      Content = "Thank you for trying out this app!",
                  }
             );
    }

    public static void SeedAccounts(DatabaseContext context)
    {
        context.Accounts.AddRange(
                 new Account
                 {
                     AccountId = "111111111111",
                     AccountName = "Checking Account",
                     UserName = "user1",
                     AccountType = AccountType.Checking,
                     Balance = 1241.56,
                     Interest = 0,
                 }, new Account
                 {
                     AccountId = "222222222222",
                     AccountName = "Emergency Funds",
                     UserName = "user1",
                     AccountType = AccountType.Savings,
                     Balance = 100000,
                     Interest = 3.75,

                 }, new Account
                 {
                     AccountId = "333333333333",
                     AccountName = "College Savings",
                     UserName = "user1",
                     AccountType = AccountType.Savings,
                     Balance = 6000,
                     Interest = 3.5,
                 }
             );
    }

    public static void SeedCards(DatabaseContext context)
    {
        context.Cards.AddRange(
                 new Card
                 {
                     AccountId = "111111111111",
                     CardId = "CC_Classic_111111111",
                     CardTier = CardTier.Classic,
                     Embossing = "User One",
                     CardType = CardType.Credit,

                 }, new Card
                 {
                     AccountId = "111111111111",
                     CardId = "CC_Classic_222222222",
                     CardTier = CardTier.Classic,
                     Embossing = "User One",
                     CardType = CardType.Credit,

                 }, new Card
                 {
                     AccountId = "111111111111",
                     CardId = "CC_Premium",
                     CardTier = CardTier.Premium,
                     Embossing = "User One",
                     CardType = CardType.Credit,
                 }, new Card
                 {
                     AccountId = "111111111111",
                     CardId = "DBT_Carbon",
                     CardTier = CardTier.Carbon,
                     Embossing = "User One",
                     CardType = CardType.Debit,
                 }, new Card
                 {
                     AccountId = "111111111111",
                     CardId = "DBT_Stellar",
                     CardTier = CardTier.Stellar,
                     Embossing = "User One",
                     CardType = CardType.PrePaid,
                 }
             ); ;
    }
}
