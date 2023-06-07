using Domain.DTOS.Account;
using Domain.DTOS.Product;
using Domain.Entitis.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Type.Type;

namespace Application.Services.Interface
{
    public interface IProductService
    {

        Task<SaveResulte> RegisterProductAsync(productDTOs productDTOs);
        //admin site
        void Addproduct(Product product);
        void Removeproduct(Product product, long id);
        void Updateproduct(Product product, long id);

        Task<bool> checkNameProduct(string NameProduct);

        // admin site & user
        Task<Product> GetByIdproduct(int id);
        Task<IEnumerable<Product>> GetAllproduct();
    }
}
