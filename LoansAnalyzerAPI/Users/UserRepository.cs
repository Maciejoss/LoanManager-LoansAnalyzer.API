using LoansAnalyzerAPI.OAuthProvider;
using Microsoft.EntityFrameworkCore;

namespace LoansAnalyzerAPI.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        private readonly OAuthService _oAuthService;

        public UserRepository(UserContext context, OAuthService oAuthService)
        {
            _context = context;
            _oAuthService = oAuthService;
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client?> GetClientByIdAsync(Guid id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client> LoginWithGoogle(string credential)
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

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
