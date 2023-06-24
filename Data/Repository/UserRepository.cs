using Data.Context;
using Domain.DTOS.Account;
using Domain.Entitis.Product;
using Domain.Entitis.user;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly BestKalaContext appContext;

        public UserRepository(BestKalaContext appContext)
        {
            this.appContext = appContext;
        }

        public  async Task adduser(User user)
        {
           this.appContext.Users.Add(user);
           await appContext.SaveChangesAsync();
        }

        public async Task<bool> checkExists(string email)
        {
            return await appContext.Users.AnyAsync(x => x.Email == email);
        }

        public async Task ConfirmEmailAsync(User user,string email)
        {
            try
            {
               


                var userid = this.appContext.Users.FirstOrDefaultAsync(user => user.Email == email);
                if (userid != null)
                {
                  
                    appContext.Users.Update(user);
               
                    
                    await appContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        public async Task<IEnumerable<User>> GetAlluser()
        {
            return await this.appContext.Users.ToListAsync();
        }

        public async Task<User> GetByemail(string email)
        {
            return await this.appContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User?> GetbyEmailPassword(string email,string password)
        {
            return await this.appContext.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password==password);
        }

        public async Task<User> GetById(int id)
        {
            return await this.appContext.Users.FirstOrDefaultAsync(user=>user.UserId==id);
            
        }

      

        public async Task removeuser(User user, long id)
        {
            var userid = this.appContext.Users.FirstOrDefaultAsync(user => user.UserId == id);
            if (userid != null)
            {
                this.appContext.Users.Remove(user);
                await appContext.SaveChangesAsync();
            }
        }

        public async Task update(User user,long id)
        {
           var userid=this.appContext.Users.FirstOrDefaultAsync(user => user.UserId == id);
            if (userid!=null)
            {
                await Task.Delay(3000);
                appContext.Users.Update(user);
               
                await appContext.SaveChangesAsync();
            }


        }

     
    }
}
