using LoansAnalyzerAPI.Enums;
using LoansAnalyzerAPI.Users.Clients;
using LoansAnalyzerAPI.Users.Employees;

namespace LoansAnalyzerAPI.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public UserType userClaims { get; private set; }

        public UserDto(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            Surname = employee.Surname;
            Email = employee.Email;
            userClaims = UserType.BankEmployee;
        }

        public UserDto(Client client)
        {
            Id = client.Id;
            Name = client.Name;
            Surname = client.Surname;
            Email = client.Email;
            userClaims = UserType.Client;
        }
    }
}
