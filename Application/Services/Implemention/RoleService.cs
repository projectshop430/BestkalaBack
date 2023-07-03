using Application.Senders.Mail;
using Application.Services.Interface;
using Data.Repository;
using Domain.DTOS.User;
using Domain.Entitis.user;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Type.Type;

namespace Application.Services.Implemention
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _iRoleRepository;
        private readonly ISendmail _sendmail;


        public RoleService(IRoleRepository iRoleRepository,ISendmail sendmail)
        {
            _iRoleRepository = iRoleRepository;
            _sendmail = sendmail;
        }

        public async Task AddRole(Roles roles)
        {
            await this._iRoleRepository.AddRole(roles);
        }

        public async Task<bool> checkRole(string namerole)
        {
            return await this._iRoleRepository.checkRole(namerole);
        }

        public async Task<Roles> GetRoleById(int roleId)
        {
           return await this._iRoleRepository.GetRoleById(roleId);
        }

        public async Task isshows(int roleId)
        {
                await this._iRoleRepository.GetRoleById(roleId);
        }

        public async Task<IEnumerable<Roles>> ListAllRole()
        {
            return await this._iRoleRepository.ListAllRole();
        }

        public async Task<RegisterResult> RegisterRole(RoleDTO roleDTO)
        {
            Roles roles = new Roles()
            {
               
                Namerole = roleDTO.Namerole,
                IsShow = roleDTO.IsShow,
                source = roleDTO.source,
            };
            await this._iRoleRepository.AddRole(roles);
            _sendmail.send("datingapp1402@gmail.com","نقش"+roles. Namerole, roles.Namerole+"---"+roles.source+"---"+roles.IsShow);
            return RegisterResult.success;
        }

        public async Task UpdateRole(Roles roles, int roleId)
        {
          await  this._iRoleRepository.UpdateRole(roles, roleId);
        }
    }

}
