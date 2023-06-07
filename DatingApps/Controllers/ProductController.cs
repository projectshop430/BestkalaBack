using Application.Services.Interface;
using Domain.Entitis.Product;
using Domain.Entitis.user;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingApps.Controllers
{
 
    public class ProductController : BaseSiteController
    {
        public readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;

        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<Product?>> GetProductsAsync()
        {
            return await _productService.GetAllproduct();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<Product?> GetProduct(int id)
        {
            return await _productService.GetByIdproduct(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
