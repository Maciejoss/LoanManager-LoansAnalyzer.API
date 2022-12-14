﻿using LoansAnalyzerAPI.Users.Clients;
using Microsoft.AspNetCore.Mvc;

namespace LoansAnalyzerAPI.Users.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetClients()
        {
            try
            {
                var clients = await _userRepository.GetAllClientsAsync();
                return clients.Count() > 0 ? Ok(clients) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get Clients: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClientByID(Guid id)
        {
            try
            {
                var client = await _userRepository.GetClientByIdAsync(id);
                return client is not null ? Ok(client) : NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest($"Failed to get Client with Id {id}: {ex.Message}");
            }
        }


        [HttpPost("LoginWithGoogle")]
        public async Task<ActionResult> LoginWithGoogle([FromBody] string credential)
        {
            try
            {
                var client = await _userRepository.LoginWithGoogle(credential);
                return Ok(client);
            }
            catch(Exception ex)
            {
                return BadRequest($"User login failed: {ex.Message}");
            }         
        }
    }
}