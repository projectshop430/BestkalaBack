using Data.Context;
using Domain.Entitis.Product;
using Domain.Entitis.user;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ProductRepository : IproductRepository
    {
        public readonly BestKalaContext appContext;

        public ProductRepository(BestKalaContext appContext)
        {
            this.appContext = appContext;
        }

        public async Task Addproduct(Product product)
        {
            this.appContext.products.Add(product);
            await appContext.SaveChangesAsync();
        }

        public async Task<bool> checkIDProduct(int id)
        {
            return await appContext.products.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> checkNameProduct(string NameProduct)
        {
            return await appContext.products.AnyAsync(x => x.Name == NameProduct);

        }

        public async Task<IEnumerable<Product>> GetAllproduct()
        {
            return await this.appContext.products.ToListAsync();
        }

        public async Task<Product> GetByIdproduct(int id)
        {
            return await this.appContext.products.FirstOrDefaultAsync(product => product.Id == id);
        }

        public async Task Removeproduct(Product product, long id)
        {
            var productid = this.appContext.products.FirstOrDefaultAsync(product => product.Id == id);
            if (productid != null)
            {
                this.appContext.products.Remove(product);
                await appContext.SaveChangesAsync();
            }
        }

        public async Task Updateproduct(Product product, long id)
        {
            var productid = this.appContext.products.FirstOrDefaultAsync(product => product.Id == id);
            if (productid != null)
            {
                appContext.products.Update(product);
                await appContext.SaveChangesAsync();
            }
        }
    }
}
