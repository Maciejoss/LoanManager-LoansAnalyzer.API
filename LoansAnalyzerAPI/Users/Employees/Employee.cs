namespace LoansAnalyzerAPI.Users.Employees
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }

        public Employee(string name, string surname, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Email = email;
        }
    }
}
