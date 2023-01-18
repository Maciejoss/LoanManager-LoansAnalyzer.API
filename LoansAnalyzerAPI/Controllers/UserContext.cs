using LoansAnalyzerAPI.Models.Clients;
using Microsoft.EntityFrameworkCore;

namespace LoansAnalyzerAPI.Controllers

{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
    }
}
