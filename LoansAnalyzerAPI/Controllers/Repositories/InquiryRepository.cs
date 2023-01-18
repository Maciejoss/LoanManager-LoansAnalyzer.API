using LoansAnalyzerAPI.Controllers.Repositories.Interfaces;
using LoansAnalyzerAPI.DTOs;
using Microsoft.Extensions.Options;

namespace LoansAnalyzerAPI.Controllers.Repositories
{
    public class InquiryRepository : IInquiryRepository
    {
        private readonly ControllersSettings _settings;
        private readonly HttpClient _client;

        public InquiryRepository(HttpClient client, IOptions<ControllersSettings> settings)
        {
            _client = client;
            _settings = settings.Value;
        }

        public async Task<IEnumerable<InquiryDto>?> GetAllInquiriesAsync()
        {
            IEnumerable<InquiryDto>? inquiries = null;
            HttpResponseMessage response = await _client.GetAsync(_settings.OurApiUrl + "/Inquiry");
            if (response.IsSuccessStatusCode)
            {
                inquiries = await response.Content.ReadFromJsonAsync<IEnumerable<InquiryDto>>();
            }
            return inquiries;
        }
    }
}
