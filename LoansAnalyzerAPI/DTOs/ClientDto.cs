using LoansAnalyzerAPI.Models.Clients;
using LoansAnalyzerAPI.Models.Clients.AdditionalData;

namespace LoansAnalyzerAPI.DTOs
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public JobDetails? JobDetails { get; set; }
        public GovernmentDocument? GovernmentDocument { get; set; }

        public ClientDto() {}

        public Client GetClient()
        {
            return new Client(Id,Name,Surname,Email,BirthDate,JobDetails,GovernmentDocument);
        }
    }
}
