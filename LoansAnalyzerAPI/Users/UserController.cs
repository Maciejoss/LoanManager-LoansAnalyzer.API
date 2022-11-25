using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoansAnalyzerAPI.Users
{
    /*[Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
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
    }*/

    public class AuthController : Controller
    {
        private readonly UserContext _context;
        private readonly AppSettings _applicationSettings;

        public AuthController(UserContext context, IOptions<AppSettings> settings)
        {
            _context = context;
            _applicationSettings = settings.Value;
        }

        [HttpPut("LoginWithGoogle")]
        public async Task<ActionResult> LoginWithGoogle([FromBody] string credential)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { this._applicationSettings.GoogleCliendId }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(credential, settings);

            //var user = _context.Clients.Where(x => x.Email == payload.Email).FirstOrDefault();

            //_context.Clients.Add(new Client() { Id = Guid.NewGuid(), Name = payload.GivenName, Surname = payload.FamilyName, Email = payload.Email });

            var client = new Client(Guid.NewGuid(), payload.GivenName, payload.FamilyName, payload.Email);

            // TODO
            //_context.Clients.Add(client);            
            //_context.SaveChanges();

            return Ok(new { token = credential, user = payload });
        }

        // Function generating Json Web Token - for own login/registration implementation
        /*public dynamic JWTGenerator(Client client)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._applicationSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", client.Name) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return new { token = encryptedToken, username = client.Name };
        }*/
    }


    public class AppSettings
    {
        //public string Secret { get; set; } - for own login/registration implementation
        public string GoogleCliendId { get; set; }
    }

}
