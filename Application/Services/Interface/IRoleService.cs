using Domain.DTOS.User;
using Domain.Entitis.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Type.Type;

namespace Application.Services.Interface
{
    public interface IRoleService
    {
       

        Task<RegisterResult> RegisterRole(RoleDTO roleDTO);


        Task AddRole(Roles roles);
        Task isshows(int roleId);
        Task UpdateRole(Roles roles, int roleId);

        Task<bool> checkRole(string namerole);

        Task<IEnumerable<Roles>> ListAllRole();
        Task<Roles> GetRoleById(int roleId);
    }
}
