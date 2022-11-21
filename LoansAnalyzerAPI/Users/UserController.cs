using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoansAnalyzerAPI.Users
{
    [Route("[controller]")]
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
    }
}
