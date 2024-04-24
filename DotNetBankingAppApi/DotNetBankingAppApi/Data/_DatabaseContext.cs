using DotNetBankingAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetBankingAppApi.Data;

public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Message> Messages { get; set; } = default!;
    public DbSet<Account> Accounts { get; set; } = default!;
    public DbSet<Card> Cards { get; set; } = default!;

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) { }

}