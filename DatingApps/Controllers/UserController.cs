using Application.Services.Interface;
using DatingApps.Controllers;
using Domain.Entitis.user;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DatingApp.Controllers
{
    
    public class UserController : BaseSiteController
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
            
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User?>> GetUsersAsync()
        {
            return await _userService.GetAlluser();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<User?> GetUser(int id)
        {
            return await _userService.GetById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
