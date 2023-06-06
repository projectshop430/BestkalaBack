using Application.Convertors;
using Application.Security.PassordHelper;
using Application.Senders.Mail;
using Application.Senders.SMS;
using Application.Services.Interface;
using Domain.DTOS.Account;
using Domain.Entitis.user;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using static Domain.Type.Type;

namespace Application.Services.Implemention
{
    public class UserService : IUserService
    {
        public readonly IUserRepository userRepository;
        public readonly IPasswordHelper passwordHeler;
        public readonly IViewRender viewRender;
        public readonly ISendmail sendmail;
        

        public UserService(IUserRepository userRepository, IPasswordHelper passwordHeler, IViewRender viewRender, ISendmail sendmail)
        {
            this.userRepository = userRepository;
            this.passwordHeler=passwordHeler;
            this.viewRender=viewRender;
            this.sendmail= sendmail;
        }

        public void adduser(User user)
        {
            this.userRepository.adduser(user);
        }

        public async Task<IEnumerable<User>> GetAlluser()
        {
           return await this.userRepository.GetAlluser();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await userRepository.GetByemail(email.ToLower().Trim());
        }

        public async Task<User> GetById(int id)
        {
           return await userRepository.GetById(id);
        }

        public async Task<LoginResult> LoginUserAsync(LoginDto LoginDTO)
        {
            string Hash = passwordHeler.Haspassword(LoginDTO.password);
            User? user = await userRepository.GetbyEmailPassword(LoginDTO.Email.ToLower().Trim(), Hash);
            if (user is null)
                return LoginResult.EmailNotfound;
            if (!user.IsEmailActive)
                return LoginResult.EmailNotAcitve;

            return LoginResult.success;
        }

        public async Task<RegisterResult> RegisterUserAsync(RegisterDto registerDTO)
        {
            if (await userRepository.checkExists(registerDTO.Email))
                return RegisterResult.Emailexit;
            else
            {
                string usernameTemp = registerDTO.Email.Split('@')[0];
                string Hash=passwordHeler.Haspassword(registerDTO.password);
                User user = new User()
                {
                    Email = registerDTO.Email.ToLower().Trim(),
                    Avatar = "Default.png",
                    IsEmailActive = false,
                    Phonenumber = null,
                    Password = passwordHeler.Haspassword(registerDTO.password),
                    RegisterDate = DateTime.Now,
                    Username = registerDTO.Email.Split('@')[0]
                };

                string body = viewRender.RenderToStringAsync("VeryfiyRegisterAccount", new { });
                sendmail.send(user.Email, "فعال سازی حساب کاربری", body);
                //save done set
                await userRepository.adduser(user);

                return RegisterResult.success;

            }
          
        }

        public void removeuser(User user, long id)
        {
            this.userRepository.removeuser(user, id); 
        }

        public void update(User user, long id)
        {
            this.userRepository.update(user, id);
        }
    }
}
