using Domain.DTOS.Account;
using Domain.Entitis.user;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Type.Type;

namespace Application.Services.Interface
{
    public interface IUserService
    {
     


        Task<RegisterResult> RegisterUserAsync(RegisterDto registerDTO);
        Task<LoginResult> LoginUserAsync(LoginDto registerDTO);
        Task<SaveResulte> ConfirmEmailAsync(User user,string email);

        Task<User> GetById(int id);
        //List user view show to Async
        Task<IEnumerable<User>> GetAlluser();
        Task adduser(User user);
        Task removeuser(long id);
        Task update(User user, long id);
 
        Task<User> GetByEmail(string email);


    }
}
