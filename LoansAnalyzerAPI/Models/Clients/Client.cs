using LoansAnalyzerAPI.Models.Clients.AdditionalData;

namespace LoansAnalyzerAPI.Models.Clients
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public JobDetails? JobDetails { get;  set; }
        public GovernmentDocument? GovernmentDocument { get; set; }

        public Client(string name, string surname, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Email = email;
        }
    }
}
