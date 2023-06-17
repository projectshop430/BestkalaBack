using Domain.Entitis.Favorite;
using Domain.Entitis.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IFavoriteRepository
    {
        Task addFavorite(Favorite favorite);
        Task removeFavorite(Favorite favorite, long id);
        Task updateFavorite(Favorite favorite, long id);
       Task<IEnumerable<Favorite>> getAllFavorite();
        Task<bool> checkByIdFavorite(int id);
        Task<Favorite> GetByIdFavorite(int ProductId);

       
    }
}
