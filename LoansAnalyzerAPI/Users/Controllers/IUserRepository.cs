using LoansAnalyzerAPI.Users.Clients;

namespace LoansAnalyzerAPI.Users.Controllers
{
    public interface IUserRepository
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<Client?> GetClientByIdAsync(Guid id);
        Task<bool> SaveAsync();
        Task<Client> LoginWithGoogle(string credential);
    }
}