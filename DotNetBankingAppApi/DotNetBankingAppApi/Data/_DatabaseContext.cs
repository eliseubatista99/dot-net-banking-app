using BankingAppApi.Models.User;
using Microsoft.EntityFrameworkCore;

namespace BankingAppApi.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; } = default!;
        //public DbSet<Policy> Policies { get; set; } = default!;
        //public DbSet<Sinister> Sinisters { get; set; } = default!;

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) { }

    }
}
