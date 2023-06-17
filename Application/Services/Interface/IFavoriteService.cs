using Domain.DTOS.Favorite;
using Domain.DTOS.Product;
using Domain.Entitis.Favorite;
using Domain.Entitis.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Type.Type;

namespace Application.Services.Interface
{
    public interface IFavoriteService
    {
        Task<bool> checkByIdFavorite(int id);
        Task<FavoriteResult> RegisterFavoriteAsync(FavoriteDto favoriteDto);

        Task addFavorite(Favorite favorite);
        Task removeFavorite(Favorite favorite, long id);
        Task updateFavorite(Favorite favorite, long id);
        Task<IEnumerable<Favorite>> getAllFavorite();

        Task<Favorite> GetByIdFavorite(int ProductId);
    }
}
