using Domain.DTOS.Account;
using Domain.Entitis.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Type.Type;

namespace Domain.Interface
{
    public interface IUserRepository
    {
        Task<User> GetByemail(string email);
        Task<User> GetById(int id);
        //List user view show to Async
        Task<IEnumerable<User>> GetAlluser();
        Task adduser(User user);
        Task removeuser(long id);
        Task update(User user,long id);
 
        Task<bool> checkExists(string email);

        Task<User?> GetbyEmailPassword(string email,string password);

    }
}
