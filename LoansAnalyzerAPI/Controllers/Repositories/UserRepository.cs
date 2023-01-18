using LoansAnalyzerAPI.Controllers.Repositories.Interfaces;
using LoansAnalyzerAPI.DTOs;
using LoansAnalyzerAPI.Models.Clients;
using LoansAnalyzerAPI.Models.Employees;
using LoansAnalyzerAPI.OAuthProvider;
using LoansAnalyzerAPI.Security;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LoansAnalyzerAPI.Controllers.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        private readonly OAuthService _oAuthService;
        private readonly JwtTokenService _jwtTokenService;
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;

        public UserRepository(UserContext context,
            OAuthService oAuthService,
            JwtTokenService jwtTokenService,
            IConfiguration configuration)
        {
            _context = context;
            _oAuthService = oAuthService;
            _jwtTokenService = jwtTokenService;
            _config = configuration;
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client?> GetClientByIdAsync(Guid id)
        {
            return await _context.Clients.FindAsync(id);
        }
        
        public async Task<UserDto> LoginUserAsync(string credential)
        {
            var employee = await LoginEmployeeAsync(credential);

            UserDto user;
            
            if (employee is not null)
            {
                user = new UserDto(employee);
            }
            else
            {
                var client = await LoginClientAsync(credential);
                user = new UserDto(client);
            }
            
            user.BearerToken = _jwtTokenService.BuildJwtToken(user.Name);
            return user;
        }

        public async Task SaveClientDataAsync(ClientDto clientInfo)
        {
            var client = await _context.Clients.SingleOrDefaultAsync(x => x.Id == clientInfo.Id);
            if (client is not null)
            {
                client.Name = clientInfo.Name;
                client.Surname = clientInfo.Surname;
                client.BirthDate = clientInfo.BirthDate;
                client.GovernmentDocument = clientInfo.GovernmentDocument;
                client.JobDetails = clientInfo.JobDetails;
            }
        }

        public async Task<Client> LoginClientAsync(string credential)
        {
            var payload = await _oAuthService.GetPayloadAsync(credential);
            
            var client = await _context.Clients
                  .Where(c => c.Email == payload.Email).FirstOrDefaultAsync();

            if (client is null)
            {
                client = new Client(payload.GivenName, payload.FamilyName?? "", payload.Email);

                await _context.Clients.AddAsync(client);
                await SaveAsync();
            }

            return client;
        }

        public async Task<Employee?> LoginEmployeeAsync(string credential)
        {
            var payload = await _oAuthService.GetPayloadAsync(credential);
            var bankUrl = _config.GetSection("BankApiUrls").GetValue<string>("OurApiUrl");

            var response = await _httpClient.GetAsync(bankUrl + "/User/Employee/" + payload.Email);
            
            if (!response.IsSuccessStatusCode) return null;
            
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Employee>(responseContent);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
