using LoansAnalyzerAPI.DTOs;
using LoansAnalyzerAPI.Models.Clients;
using LoansAnalyzerAPI.Models.Employees;

namespace LoansAnalyzerAPI.Controllers.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<Client?> GetClientByIdAsync(Guid id);
        Task<bool> SaveAsync();
        Task<Client> LoginClientAsync(string credential);
        Task<Employee?> LoginEmployeeAsync(string credential);
        Task<UserDto> LoginUserAsync(string credential);
    }
}