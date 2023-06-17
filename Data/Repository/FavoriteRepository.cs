using Data.Context;
using Domain.Entitis.Favorite;
using Domain.Entitis.Product;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly BestKalaContext appContext;

        public FavoriteRepository(BestKalaContext bestKalaContext)
        {
            appContext = bestKalaContext;
        }

        public async Task addFavorite(Favorite favorite)
        {
          this.appContext.Favorites.Add(favorite);
           await appContext.SaveChangesAsync();
        }

        public async Task<bool> checkByIdFavorite(int id)
        {
            return await appContext.Favorites.AnyAsync(x => x.id == id);
        }

        public async Task<IEnumerable<Favorite>> getAllFavorite()
        {
            return await   this.appContext.Favorites.ToListAsync();
        }

        public async Task<Favorite> GetByIdFavorite(int ProductId)
        {
            return await this.appContext.Favorites.SingleOrDefaultAsync(x=>x.productId==ProductId);
        }

       

        public async Task removeFavorite(Favorite favorite, long id)
        {
            var Favoritesid = this.appContext.Favorites.FirstOrDefaultAsync(Favorites => Favorites.id == id);
            if (Favoritesid != null)
            {
                this.appContext.Favorites.Remove(favorite);
                await appContext.SaveChangesAsync();
            }
        }

        public async Task updateFavorite(Favorite favorite, long id)
        {
            var Favoritesid = this.appContext.Favorites.FirstOrDefaultAsync(Favorites => Favorites.id == id);
            if (Favoritesid != null)
            {
                this.appContext.Favorites.Update(favorite);
                await appContext.SaveChangesAsync();
            }
        }
    }
}
