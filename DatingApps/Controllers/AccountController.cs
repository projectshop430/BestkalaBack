
using Application.Services.Interface;
using Domain.DTOS.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Domain.Type.Type;
using Microsoft.AspNetCore.Mvc.Controllers;
using Domain.DTOS.Common;
using BestKalas.Services.Interface;
using Domain.DTOS.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;
using Application.Convertors;
using Application.Senders.Mail;
using Domain.Entitis.user;
using Newtonsoft.Json.Linq;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;

namespace BestKalas.Controllers
{
  
    public class AccountController : BaseSiteController
    {
        #region Constructor

        private readonly IUserService _userService;

        private readonly ITokenServices _tokenServices;
        public readonly IViewRender viewRender;
        public readonly ISendmail sendmail;
        private string error="error system";
        public AccountController(IUserService userService, ITokenServices tokenServices, IViewRender viewRender, ISendmail sendmail)
        {
            _userService = userService;
            _tokenServices = tokenServices;
            this.viewRender = viewRender;
            this.sendmail = sendmail;
        }

        #endregion

        #region Login

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDTO)
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = new List<string>();
                foreach (var modelerorr in ViewData.ModelState.Values)
                {
                    foreach (var error in modelerorr.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }

                }
                return new JsonResult(new ResponResult(false,"kar",errors));
            }
            LoginResult res = await _userService.LoginUserAsync(loginDTO);
            switch (res)
            {
                case LoginResult.success:
                    var user = await _userService.GetByEmail(loginDTO.Email);

                    if (user == null)
                    {
                        return new JsonResult(new ResponResult(false, "متاسفانه حساب کاربری شما یافت نشد"));

                    }
                    return new JsonResult(new ResponResult(true, "حساب کاربری ما خوش آمدید", new UserDTO
                    {
                        Usernamea = user.Usernamea,
                        Token = _tokenServices.CreateToken(user,10)
                    })); ; 
                    ;
                case LoginResult.error:
                    return new JsonResult(new ResponResult(false, "لطفا مجدد تلاش کنید"));

                    
                case LoginResult.EmailNotAcitve:
                    return new JsonResult(new ResponResult(false, "ایمیل اکتیو نیست"));

                case LoginResult.EmailNotfound:
                    return new JsonResult(new ResponResult(false, "ایمیل وجود ندارد"));

                    
                default:
                    break;
            }

            return new JsonResult(new ResponResult(false, "خطایی رخ داده است"));
        }

        #endregion

        #region Register

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDTO)
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = new List<string>();
                foreach (var modelerorr in ViewData.ModelState.Values)
                {
                    foreach (var error in modelerorr.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }

                }
                return new JsonResult(new ResponResult(false, "", errors));
            }
            RegisterResult res = await _userService.RegisterUserAsync(registerDTO);

            

            
          

       

            switch (res)
            {
                case RegisterResult.success:

                  
                    var user = await _userService.GetByEmail(registerDTO.Email);
                    UserDTO userDTO = new UserDTO()
                    {
                        Usernamea = user.Usernamea,
                        Token = _tokenServices.CreateToken(user,10)
                    };
                    var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new {email=user.Email, token = userDTO.Token }, Request.Scheme);
                    string body = viewRender.RenderToStringAsync("VeryfiyRegisterAccount", new {  })+ confirmationLink;
                    sendmail.send(registerDTO.Email, "فعال سازی حساب کاربری", body);
                    if (user == null)
                    {
                        return new JsonResult(new ResponResult(false, "متاسفانه حساب کاربری شما یافت نشد"));

                    }
                    return new JsonResult(new ResponResult(true, "حساب کاربری ما خوش آمدید"));
                  

                case RegisterResult.error:
                    return new JsonResult(new ResponResult(false, "مشکلی پیش آمده است. لطفا مجدد تلاش کنید"));
                   
                case RegisterResult.Emailexit:
                    return new JsonResult(new ResponResult(false, "ایمیل وارد شده از قبل ثبت نام کرده است"));
                   
                default:
                    break;
            }


            return new JsonResult(new ResponResult(false, "خطایی رخ داده است"));
        }

        #endregion
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string email,string token)
        {
           
           

                var user1 = await _userService.GetByEmail(email);
                if (user1 == null)
                    return View("Error");
                if (user1.IsEmailActive != true)
                {
                await Task.Delay(2000); 
                SaveResulte res = await _userService.ConfirmEmailAsync(user1, email);

                    switch (res)
                    {
                    case SaveResulte.success:

                        return new RedirectResult("http://localhost:4200/FormLogin");

                        case SaveResulte.error:
                            return new JsonResult(new ResponResult(false, "error save rusulte"));



                        default:
                            break;
                    }


                
                }
            else
            {
                return new JsonResult(new ResponResult(false, "It was already active "));
            }
            
            
                return new JsonResult(new ResponResult(false, error));
            

          

        }



        #region Forgot password

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPassword forgotPasswordDTO)
        {
            return Ok();
        }

        #endregion
    }
}
