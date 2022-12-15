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
        Task<Client> LoginClient(string credential);
        Task<Employee> LoginEmployee(string credential);
        Task<ActionResult> LoginUser(string credential);
    }
}