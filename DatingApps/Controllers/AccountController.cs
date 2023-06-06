
using Application.Services.Interface;
using Domain.DTOS.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Domain.Type.Type;
using Microsoft.AspNetCore.Mvc.Controllers;
using Domain.DTOS.Common;
using DatingApps.Services.Interface;
using Domain.DTOS.User;

namespace DatingApps.Controllers
{
  
    public class AccountController : BaseSiteController
    {
        #region Constructor

        private readonly IUserService _userService;

        private readonly ITokenServices _tokenServices;
    

        public AccountController(IUserService userService, ITokenServices tokenServices)
        {
            _userService = userService;
            _tokenServices = tokenServices;
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
                return new JsonResult(new ResponResult(false,"",errors));
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
                        UserName = user.Username,
                        Token = _tokenServices.CreateToken(user)
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

                    if (user == null)
                    {
                        return new JsonResult(new ResponResult(false, "متاسفانه حساب کاربری شما یافت نشد"));

                    }
                    return new JsonResult(new ResponResult(true, "حساب کاربری ما خوش آمدید", new UserDTO
                    {
                        UserName = user.Username,
                        Token = _tokenServices.CreateToken(user)
                    })); ;

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


        #region Forgot password

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPassword forgotPasswordDTO)
        {
            return Ok();
        }

        #endregion
    }
}
