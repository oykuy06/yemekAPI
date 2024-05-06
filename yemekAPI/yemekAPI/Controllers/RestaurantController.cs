using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yemekAPI.Models;

namespace yemekAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly YemekAPIContext _dbContext;

        public RestaurantController(YemekAPIContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
            if (_dbContext.Restaurants == null)
            {
                return NotFound();
            }

            return await _dbContext.Restaurants.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Restaurant>> Getrestaurants(int id)
        {
            if (_dbContext.Restaurants == null)
            {
                return NotFound();
            }

            var restaurant = await _dbContext.Restaurants.FindAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }

        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostRestaurant(string KategoriId, string Ad, string Adres, string Tel)
        {
            if (string.IsNullOrEmpty(Ad) || string.IsNullOrEmpty(Adres) || string.IsNullOrEmpty(Tel))
            {
                return BadRequest("Required fields are missing.");
            }

            if (!int.TryParse(KategoriId, out int parsedKategoriId))
            {
                return BadRequest("Invalid AdresId.");
            }

            Restaurant restaurant = new()//restaurant
            {
                Ad = Ad,
                Adres = Adres,
                Tel = Tel,
                KategoriId = parsedKategoriId
            };

            _dbContext.Restaurants.Add(restaurant);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRestaurants), new { id = restaurant.KategoriId }, restaurant);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Restaurant>> PutRestaurant(int id, string Ad, string Adres, string Tel)
        {
            if (string.IsNullOrEmpty(Ad) || string.IsNullOrEmpty(Adres) || string.IsNullOrEmpty(Tel))
            {
                return BadRequest("Required fields are missing.");
            }

            var existingRestaurant = await _dbContext.Restaurants.FindAsync(id);

            if (existingRestaurant == null)
            {
                return NotFound();
            }

            existingRestaurant.Ad = Ad;
            existingRestaurant.Adres = Adres;
            existingRestaurant.Tel = Tel;

            await _dbContext.SaveChangesAsync();

            return existingRestaurant;
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var restaurant = await _dbContext.Restaurants.FindAsync(id);

            if (restaurant == null)
            {
                return NotFound("In correct customer id");
            }

            _dbContext.Restaurants.Remove(restaurant);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

    }
}
