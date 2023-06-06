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

        Task<User> GetById(int id);
        //List user view show to Async
        Task<IEnumerable<User>> GetAlluser();
        void adduser(User user);
        void removeuser(User user, long id);
        void update(User user, long id);

        Task<User> GetByEmail(string email);


    }
}
