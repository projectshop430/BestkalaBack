using Application.Convertors;
using Application.Security.PassordHelper;
using Application.Senders.Mail;
using Application.Services.Interface;
using Data.Repository;
using Domain.DTOS.Account;
using Domain.DTOS.Product;
using Domain.Entitis.Product;
using Domain.Entitis.user;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Type.Type;

namespace Application.Services.Implemention
{
    public class ProductService : IProductService


    {

        public readonly IproductRepository productRepository;
      
        public readonly IViewRender viewRender;


        public ProductService(IproductRepository productRepository, IViewRender viewRender)
        {
            this.productRepository = productRepository;
            this.viewRender = viewRender;
        }

        public void Addproduct(Product product)
        {
            this.productRepository.Addproduct(product);
        }

        public async Task<bool> checkNameProduct(string NameProduct)
        {
            return await this.productRepository.checkNameProduct(NameProduct);

        }

        public async Task<IEnumerable<Product>> GetAllproduct()
        {
            return await this.productRepository.GetAllproduct();
        }

        public async Task<Product> GetByIdproduct(int id)
        {
            return await this.productRepository.GetByIdproduct(id);
        }

        public async Task<Domain.Type.Type.SaveResulte> RegisterProductAsync(productDTOs productDTOs)
        {
            if (await this.productRepository.checkNameProduct(productDTOs.Name))
                return SaveResulte.exit;
            else
            {
                Product product = new Product()
                {
                    avatar = productDTOs.Name,
                    category= productDTOs.category,
                    Name = productDTOs.Name,
                    price = productDTOs.price,

                };

                //string body = viewRender.RenderToStringAsync("VeryfiyRegisterProduct", new { });

                //save done set
                await productRepository.Addproduct(product);

                return SaveResulte.success;
            }
        }
        public void Removeproduct(Product product, long id)
        {
            this.productRepository.Removeproduct(product, id);
        }

        public void Updateproduct(Product product, long id)
        {
            this.productRepository.Updateproduct(product, id);
        }
    }
}
