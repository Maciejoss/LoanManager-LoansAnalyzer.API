using LoansAnalyzerAPI.Models.Clients.AdditionalData;
using System.Text.Json.Serialization;

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

        [JsonConstructor]
        public Client(string name, string surname, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Email = email;
        }

        public Client(Guid id, string name, string surname, string email, DateTime birthDate, JobDetails jobDetails, GovernmentDocument governmentDocument)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            BirthDate = birthDate;
            JobDetails = jobDetails;
            GovernmentDocument = governmentDocument;
        }
    }
}
