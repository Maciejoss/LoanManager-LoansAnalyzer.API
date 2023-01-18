using LoansAnalyzerAPI.Enums;
using LoansAnalyzerAPI.Models.Clients;
using LoansAnalyzerAPI.Models.Employees;

namespace LoansAnalyzerAPI.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public UserType UserClaims { get; private set; }
        public bool IsAuthenticated { get; private set; }
        public string BearerToken { get; set; }

        public UserDto(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            Surname = employee.Surname;
            Email = employee.Email;
            UserClaims = UserType.BankEmployee;
            IsAuthenticated = true;
        }

        public UserDto(Client client)
        {
            Id = client.Id;
            Name = client.Name;
            Surname = client.Surname;
            Email = client.Email;
            UserClaims = UserType.Client;
            IsAuthenticated = true;
        }
    }
}