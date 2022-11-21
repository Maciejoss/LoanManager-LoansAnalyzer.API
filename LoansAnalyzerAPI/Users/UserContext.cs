using Microsoft.EntityFrameworkCore;

namespace LoansAnalyzerAPI.Users
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
    }
}
