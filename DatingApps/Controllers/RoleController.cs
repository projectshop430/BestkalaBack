using Application.Services.Implemention;
using Application.Services.Interface;
using BestKalas.Controllers;
using Domain.Entitis.user;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BestKala.Controllers
{

    
    public class RoleController : BaseSiteController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public async Task<IEnumerable<Roles?>> GetRolesAsync()
        {
            return await _roleService.ListAllRole();
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<Roles?> GetRole(int id)
        {
            return await _roleService.GetRoleById(id);
        }

        // POST api/<RoleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
