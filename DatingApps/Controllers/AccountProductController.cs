using Application.Services.Interface;
using Domain.DTOS.Common;
using Domain.DTOS.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Domain.Type.Type;

namespace DatingApps.Controllers
{
   
    public class AccountProductController : BaseSiteController
    {
        private readonly IProductService _productService;




        public AccountProductController(IProductService ProductService)
        {
            _productService = ProductService;

        }


        #region Register

        [HttpPost("SaveKala")]

        public async Task<IActionResult> SaveKala(productDTOs productDTOs)
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
            SaveResulte res = await _productService.RegisterProductAsync(productDTOs);
            switch (res)
            {
                case SaveResulte.success:
                    var user = await _productService.checkNameProduct(productDTOs.Name);

                    if (user == null)
                    {
                        return new JsonResult(new ResponResult(false, "متاسفانه کالای مورد نظر شما یافت نشد"));

                    }
                    return new JsonResult(new ResponResult(true, "کالای مورد نظر شما ثبت شد"));

                case SaveResulte.error:
                    return new JsonResult(new ResponResult(false, "مشکلی پیش آمده است. لطفا مجدد تلاش کنید"));

                case SaveResulte.exit:
                    return new JsonResult(new ResponResult(false, "کالا وارد شده از قبل ثبت کرده است"));

                default:
                    break;
            }


            return new JsonResult(new ResponResult(false, "خطایی رخ داده است"));
        }

        #endregion

    }
}
