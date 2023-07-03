using Application.Convertors;
using Application.Security.PassordHelper;
using Application.Senders.Mail;
using Application.Senders.SMS;
using Application.Services.Interface;
using Azure.Core;
using Domain.DTOS.Account;
using Domain.Entitis.user;
using Domain.Interface;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Policy;
using System.Text;
using System.Text.Encodings.Web;
using static Domain.Type.Type;

namespace Application.Services.Implemention
{
    public class UserService : IUserService
    {
        public readonly IUserRepository userRepository;
        public readonly IPasswordHelper passwordHeler;
        private readonly ISendmail sendmail;
        public readonly ISMS sMS;
      
      


        public UserService(IUserRepository userRepository, IPasswordHelper passwordHeler,  ISendmail sendmail,ISMS sms)
        {
            this.userRepository = userRepository;
            this.passwordHeler=passwordHeler;
            this.sendmail=sendmail;
            this.sMS = sms;
          
            
        }

        public async Task adduser(User user)
        {
            await this.userRepository.adduser(user);
        }

      

        public async Task<SaveResulte> ConfirmEmailAsync(User user,string email)
        {
          
            user.IsEmailActive = true;
            await this.userRepository.update(user,user.UserId);
            return SaveResulte.success;
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
                string UsernameaTemp = registerDTO.Email.Split('@')[0];
                string Hash=passwordHeler.Haspassword(registerDTO.password);
                User user = new User()
                {
                    Email = registerDTO.Email.ToLower().Trim(),
                    Avatar = "Default.png",
                    IsEmailActive = false,
                    Phonenumbera = "9397149558",
                    Password = passwordHeler.Haspassword(registerDTO.password),
                    RegisterDate = DateTime.Now,
                    Usernamea = registerDTO.Email.Split('@')[0]
                };

               
                //save done set
                await userRepository.adduser(user);
                

                //sMS.SMsS("نام کاربری "+user.Usernamea+ "خوش آمدید ", user.Phonenumbera,user.UserId.ToString());

                return RegisterResult.success;

            }
          
        }

        public async Task removeuser( long id)
        {
            await this.userRepository.removeuser( id); 
        }

        public async Task update(User user, long id)
        {
            await this.userRepository.update(user, id);
        }

    }
}
