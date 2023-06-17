using Application.Services.Interface;
using Data.Repository;
using Domain.DTOS.Favorite;
using Domain.DTOS.Product;
using Domain.Entitis.Favorite;
using Domain.Entitis.Product;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Type.Type;

namespace Application.Services.Implemention
{
    public class FavoriteService : IFavoriteService
    {
        public readonly IFavoriteRepository favoriteRepository;
        private readonly IproductRepository productRepository;

        public FavoriteService(IFavoriteRepository favoriteRepository, IproductRepository productRepository)
        {
            this.favoriteRepository = favoriteRepository;
            this.productRepository = productRepository;
        }

        public async Task addFavorite(Favorite favorite)
        {
           await  this.favoriteRepository.addFavorite(favorite);
        }

        public async Task<bool> checkByIdFavorite(int id)
        {
            return await this.favoriteRepository.checkByIdFavorite(id);
        }

        public async Task<IEnumerable<Favorite>> getAllFavorite()
        {
           return await this.favoriteRepository.getAllFavorite();
        }

        public async Task<Favorite> GetByIdFavorite(int ProductId)
        {
            return await this.favoriteRepository.GetByIdFavorite(ProductId);
        }

        public async Task<Domain.Type.Type.FavoriteResult> RegisterFavoriteAsync(FavoriteDto favoriteDto)
        {
            

                if ((await this.favoriteRepository.checkByIdFavorite(favoriteDto.productId)==false) && (await (this.productRepository.checkIDProduct(favoriteDto.productId))))
                
                return FavoriteResult.IDexit;
            else
            {
                Favorite favorite = new Favorite()
                {
                    productId = favoriteDto.productId,
                    discount = favoriteDto.discount,


                };
                await favoriteRepository.addFavorite(favorite);
                return FavoriteResult.success;
            }
        }

        public async Task removeFavorite(Favorite favorite, long id)
        {
                await this.favoriteRepository.removeFavorite(favorite, id);
        }

        public async Task updateFavorite(Favorite favorite, long id)
        {
            await this.favoriteRepository.updateFavorite(favorite, id);
        }
    }
}
