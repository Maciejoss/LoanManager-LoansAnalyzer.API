using LoansAnalyzerAPI.Users.Clients;
using LoansAnalyzerAPI.Users.Employees;
using Microsoft.AspNetCore.Mvc;

namespace LoansAnalyzerAPI.Users.Controllers
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