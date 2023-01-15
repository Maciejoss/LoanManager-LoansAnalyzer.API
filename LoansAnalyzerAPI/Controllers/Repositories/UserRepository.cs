using LoansAnalyzerAPI.Controllers.Repositories.Interfaces;
using LoansAnalyzerAPI.DTOs;
using LoansAnalyzerAPI.OAuthProvider;
using LoansAnalyzerAPI.Users.Clients;
using LoansAnalyzerAPI.Users.Employees;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LoansAnalyzerAPI.Controllers.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        private readonly OAuthService _oAuthService;
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;

        public UserRepository(UserContext context, OAuthService oAuthService, IConfiguration configuration)
        {
            _context = context;
            _oAuthService = oAuthService;
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

            if (employee is not null)
            {
                return new UserDto(employee);
            }

            var client = await LoginClientAsync(credential);
            return new UserDto(client);
        }

        public async Task<Client> LoginClientAsync(string credential)
        {
            var payload = await _oAuthService.GetPayloadAsync(credential);

            var client = await _context.Clients
                  .Where(c => c.Email == payload.Email).FirstOrDefaultAsync();

            if (client is null)
            {
                client = new Client(payload.GivenName, payload.FamilyName ?? "", payload.Email);

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
