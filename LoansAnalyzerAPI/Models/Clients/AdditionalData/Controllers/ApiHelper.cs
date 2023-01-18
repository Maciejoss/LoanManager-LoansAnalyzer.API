using System.Net.Http.Headers;

namespace LoansAnalyzerAPI.Models.Clients.AdditionalData.Controllers
{
    public  class ApiHelper
    {
        public HttpClient ApiClient { get; set; }
        private string baseUrl { get; set; }

        public ApiHelper(IConfiguration configuration)
        {          
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            baseUrl = configuration.GetSection("BankApiUrls").GetValue<string>("LecturerApiUrl");
        }

        public async Task<HttpResponseMessage> GetJobTypes()
        {
            string url = baseUrl + "jobTypes";
            return await ApiClient.GetAsync(url);
        }
        public async Task<HttpResponseMessage> GetGovernmentDocumentTypes()
        {
            string url = baseUrl + "governmentDocumentTypes";
            return await ApiClient.GetAsync(url);
        }
    }
}
