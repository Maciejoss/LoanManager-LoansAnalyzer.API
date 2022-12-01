using Google.Apis.Auth;
using LoansAnalyzerAPI.GoogleProvider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LoansAnalyzerAPI.Users
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;
        private readonly OAuthProviderSettings _oAuthSettings;

        public UserController(UserContext context, IOptions<OAuthProviderSettings> settings)
        {
            _context = context;
            _oAuthSettings = settings.Value;
        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetClients()
        {
            return Ok(await _context.Clients.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Client>>> GetClientByID(Guid id)
        {
            var user = await _context.Clients.FindAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }


        [HttpPut("LoginWithGoogle")]
        public async Task<ActionResult> LoginWithGoogle([FromBody] string credential)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { _oAuthSettings.GoogleClientId }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(credential, settings);
            if (payload.FamilyName == null) // to be fixed in the future
            {
                payload.FamilyName = "";
            }

            var client = new Client(payload.GivenName, payload.FamilyName, payload.Email);


            // TODO
            _context.Clients.Add(client);
            _context.SaveChanges();

            return Ok(client);
        }
    }
}
