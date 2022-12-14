using LoansAnalyzerAPI.Enums;
using LoansAnalyzerAPI.Users.Employees;

namespace LoansAnalyzerAPI.Users
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }

        public UserType userClaims;

        public UserDTO(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            Surname = employee.Surname;
            Email = employee.Email;
            userClaims = UserType.BankEmployee;
        }
        
        
        
    }
}
