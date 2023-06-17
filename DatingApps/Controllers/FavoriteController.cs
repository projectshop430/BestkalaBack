using Application.Services.Implemention;
using Application.Services.Interface;
using BestKalas.Controllers;
using Domain.Entitis.Favorite;
using Domain.Entitis.Product;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BestKala.Controllers
{
   
    public class FavoriteController : BaseSiteController
    {
        public readonly IFavoriteService _FavoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _FavoriteService = favoriteService;

        }
        // GET: api/<FavoriteController>
        [HttpGet]
        public async  Task <IEnumerable<Favorite>> GetFavorites()
        {
            return await _FavoriteService.getAllFavorite();
        }

        // GET api/<FavoriteController>/5
        [HttpGet("{id}")]
        public async Task<Favorite?> GetProduct(int id)
        {
            return await _FavoriteService.GetByIdFavorite(id);
        }

        // POST api/<FavoriteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FavoriteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FavoriteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
