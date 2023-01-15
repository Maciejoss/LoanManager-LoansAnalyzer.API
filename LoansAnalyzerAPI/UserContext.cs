using LoansAnalyzerAPI.Users.Clients;
using Microsoft.EntityFrameworkCore;

namespace LoansAnalyzerAPI
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
    }
}
