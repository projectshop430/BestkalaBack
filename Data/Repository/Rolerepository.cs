using Data.Context;
using Domain.Entitis.user;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Type.Type;

namespace Data.Repository
{
    public class Rolerepository : IRoleRepository
    {
        private readonly BestKalaContext bestKalaContext;

        public Rolerepository(BestKalaContext bestKalaContext)
        {
            this.bestKalaContext = bestKalaContext;
        }

        public async Task AddRole(Roles roles)
        {
             this.bestKalaContext.roles.Add(roles);
            await bestKalaContext.SaveChangesAsync();
        }

        public async Task<bool> checkRole(string namerole)
        {
            return await this.bestKalaContext.roles.AnyAsync(x => x.Namerole == namerole);
        }

        public async Task<Roles> GetRoleById(int roleId)
        {
            return await this.bestKalaContext.roles.SingleOrDefaultAsync(x => x.idRole == roleId);
        }

        public async Task<IEnumerable<Roles>> ListAllRole()
        {
            return await this.bestKalaContext.roles.ToListAsync();
        }

      

        public async Task UpdateRole(Roles roles, int roleId)
        {
           var oldid= this.bestKalaContext.roles.SingleOrDefaultAsync(x => x.idRole == roleId);
            if (oldid!=null)
            {
                this.bestKalaContext.roles.Update(roles);
                await this.bestKalaContext.SaveChangesAsync();
            }
        }

        public async Task isshows(int roleId)
        {
            var role = this.bestKalaContext.roles.Find(roleId);
            if (role != null)
            {
                role.IsShow = true;
                this.bestKalaContext.roles.Update(role);
                await this.bestKalaContext.SaveChangesAsync();

            }
        }
    }
}
