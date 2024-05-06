using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yemekAPI.Models;

namespace yemekAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestMenüsüController : ControllerBase
    {
        private readonly YemekAPIContext _dbContext;

        public RestMenüsüController(YemekAPIContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<RestMenüsü>>> GetRestMenüsüs()
        {
            if (_dbContext.RestMenüsüs == null)
            {
                return NotFound();
            }

            return await _dbContext.RestMenüsüs.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<RestMenüsü>> GetrestMenüsüs(int id)
        {
            if (_dbContext.RestMenüsüs == null)
            {
                return NotFound();
            }

            var restMenüsü = await _dbContext.RestMenüsüs.FindAsync(id);

            if (restMenüsü == null)
            {
                return NotFound();
            }

            return restMenüsü;
        }

        [HttpPost]
        public async Task<ActionResult<RestMenüsü>> PostRestMenüsü(string MenuId, string RestaurantId)
        {
            if (!int.TryParse(MenuId, out int parsedMenuId))
            {
                return BadRequest("Invalid MenuId.");
            }

            if (!int.TryParse(RestaurantId, out int parsedRestaurantId))
            {
                return BadRequest("Invalid MenuId.");
            }

            RestMenüsü restMenüsü = new()//restmenüsü
            {
                MenuId = parsedMenuId,
                RestaurantId = parsedRestaurantId
            };

            _dbContext.RestMenüsüs.Add(restMenüsü);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRestMenüsüs), new { id = restMenüsü.RestaurantId }, restMenüsü);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RestMenüsü>> PutRestMenüsü(int id, int MenuId)
        {
            if (MenuId == default)//(int)
            {
                return BadRequest("Gerekli alanlar eksik.");
            }

            var existingRestMenüsü = await _dbContext.RestMenüsüs.FindAsync(id);

            if (existingRestMenüsü == null)
            {
                return NotFound();
            }

            existingRestMenüsü.MenuId = MenuId;
            
            await _dbContext.SaveChangesAsync();

            return existingRestMenüsü;
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var restMenüsü = await _dbContext.RestMenüsüs.FindAsync(id);

            if (restMenüsü == null)
            {
                return NotFound("In correct customer id");
            }

            _dbContext.RestMenüsüs.Remove(restMenüsü);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

    }
}
