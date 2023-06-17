using Domain.Entitis.Product;
using Domain.Entitis.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IproductRepository
    {
        //admin site
        Task Addproduct(Product product);
        Task Removeproduct(Product product, long id);
        Task Updateproduct(Product product, long id);

        Task<bool> checkNameProduct(string NameProduct);

        Task<bool> checkIDProduct(int id);
        // admin site & user
        Task<Product> GetByIdproduct(int id);
        Task<IEnumerable<Product>> GetAllproduct();



    }
}
