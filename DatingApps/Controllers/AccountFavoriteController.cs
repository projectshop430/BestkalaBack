using Application.Services.Implemention;
using Application.Services.Interface;
using BestKalas.Controllers;
using Domain.DTOS.Common;
using Domain.DTOS.Favorite;
using Domain.DTOS.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Domain.Type.Type;

namespace BestKala.Controllers
{
   
    public class AccountFavoriteController : BaseSiteController
    {
        public readonly IFavoriteService _FavoriteService;

        public AccountFavoriteController(IFavoriteService favoriteService)
        {
            _FavoriteService = favoriteService;

        }

        #region Register

        [HttpPost("SaveFavorite")]

        public async Task<IActionResult> SaveFavorite(FavoriteDto favoriteDto)
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





            FavoriteResult res = await _FavoriteService.RegisterFavoriteAsync(favoriteDto);
            switch (res)
            {
                case FavoriteResult.success:
                    var user = await _FavoriteService.checkByIdFavorite(favoriteDto.id);

                    if (user == null)
                    {
                        return new JsonResult(new ResponResult(false, "متاسفانه کالای مورد نظر شما یافت نشد"));

                    }
                    return new JsonResult(new ResponResult(true, "کالای مورد نظر شما ثبت شد"));

                case FavoriteResult.error:
                    return new JsonResult(new ResponResult(false, "مشکلی پیش آمده است. لطفا مجدد تلاش کنید"));

                case FavoriteResult.IDexit:
                    return new JsonResult(new ResponResult(false, "کالا وارد شده از قبل ثبت کرده است"));

                default:
                    break;
            }


            return new JsonResult(new ResponResult(false, "خطایی رخ داده است"));
        }

        #endregion

    
}
}
