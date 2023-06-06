using Application.Services.Interfaces;
using Domain.DTOs.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Api.Controllers
{
    public class AccountController : BaseSiteController
    {
        #region Constructor

        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Login

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            return Ok();
        }

        #endregion

        #region Register

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            RegisterReuslt res=await _userService.RegisterUserAsync(registerDTO);
            switch (res)
            {
                case RegisterReuslt.Success:
                    TempData["SuccessMessage"] = "حساب کاربری شما با موفقیت ساخته شد.";
                    break;
                case RegisterReuslt.Error:
                    TempData["ErrorMessage"] = "مشکلی پیش آمده است. لطفا مجدد تلاش کنید";
                    break;
                case RegisterReuslt.EmailIsExist:
                    TempData["ErrorMessage"] = "ایمیل وارد شده از قبل ثبت نام کرده است.";
                    break;
                default:
                    break;
            }


            return Ok();
        }

        #endregion


        #region Forgot password

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {
            return Ok();
        }

        #endregion

    }
}
