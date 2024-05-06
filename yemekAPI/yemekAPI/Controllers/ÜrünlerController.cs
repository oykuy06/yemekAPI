using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yemekAPI.Models;

namespace yemekAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ÜrünlerController : ControllerBase
    {
        private readonly YemekAPIContext _dbContext;

        public ÜrünlerController(YemekAPIContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Ürünler>>> GetÜrünlers()
        {
            if (_dbContext.Ürünlers == null)
            {
                return NotFound();
            }

            return await _dbContext.Ürünlers.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Ürünler>> GetÜrünlers(int id)
        {
            if (_dbContext.Ürünlers == null)
            {
                return NotFound();
            }

            var ürünler = await _dbContext.Ürünlers.FindAsync(id);

            if (ürünler == null)
            {
                return NotFound();
            }

            return ürünler;
        }

        [HttpPost]
        public async Task<ActionResult<Ürünler>> PostÜrünler(string Ad, string Fiyat)
        {
            if (string.IsNullOrEmpty(Ad))
            {
                return BadRequest("Required fields are missing.");
            }

            if (!int.TryParse(Fiyat, out int parsedFiyat))
            {
                return BadRequest("Invalid UserId.");
            }

            Ürünler ürünler = new()//ürünler
            {
                Ad = Ad,
                Fiyat = parsedFiyat
            };

            _dbContext.Ürünlers.Add(ürünler);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetÜrünlers), new { id = ürünler.UrunId }, ürünler);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Ürünler>> PutÜrünler(int id, string Ad, int Fiyat)
        {
            if (string.IsNullOrEmpty(Ad))
            {
                return BadRequest("Required fields are missing.");
            }

            if (Fiyat == default)//(int)
            {
                return BadRequest("Gerekli alanlar eksik.");
            }

            var existingÜrünler = await _dbContext.Ürünlers.FindAsync(id);

            if (existingÜrünler == null)
            {
                return NotFound();
            }

            existingÜrünler.Ad = Ad;
            existingÜrünler.Fiyat = Fiyat;

            await _dbContext.SaveChangesAsync();

            return existingÜrünler;
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var ürünler = await _dbContext.Ürünlers.FindAsync(id);

            if (ürünler == null)
            {
                return NotFound("In correct customer id");
            }

            _dbContext.Ürünlers.Remove(ürünler);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

    }
}
