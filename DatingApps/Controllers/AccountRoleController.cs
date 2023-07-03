using Application.Services.Implemention;
using Application.Services.Interface;
using BestKalas.Controllers;
using Domain.DTOS.Common;
using Domain.DTOS.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Domain.Type.Type;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BestKala.Controllers
{
  
    public class AccountRoleController : BaseSiteController
    {
        private readonly IRoleService _roleService;

        public AccountRoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("RegisterRoles")]
        public async Task<IActionResult> RegisterRoles(RoleDTO roleDTO)
        {
            if (!ModelState.IsValid)
            {
                List<string> Errors=new List<string>();
                foreach (var modelerror in ViewData.ModelState.Values)
                {

                    foreach (var error in modelerror.Errors)
                    {
                        Errors.Add(error.ErrorMessage);
                    }
                }
                return  new JsonResult(new ResponResult(false, "", Errors));
            }
            RegisterResult res = await  this._roleService.RegisterRole(roleDTO);

            switch (res)
            {
                case RegisterResult.success:
                    return new JsonResult(new ResponResult(true, "با موفقیت نقش ثبت شد"));
                    
                case RegisterResult.error:
                    return new JsonResult(new ResponResult(false, "با موفقیت نقش ثبت نشد"));
                default:
                    break;
            }

            return new JsonResult(new ResponResult(false, "خطایی رخ داده "));
        }
    }
}
