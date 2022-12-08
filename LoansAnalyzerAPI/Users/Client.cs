using LoansAnalyzerAPI.Users.UserInfo;

namespace LoansAnalyzerAPI.Users
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public JobDetails? JobDetails { get; private set; }
        public GovernmentDocument? GovernmentDocument { get; private set; }

        public Client(string name, string surname, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Email = email;
        }
    }
}
