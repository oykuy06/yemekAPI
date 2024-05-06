using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yemekAPI.Models;

namespace yemekAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SepetController : ControllerBase
    {
        private readonly YemekAPIContext _dbContext;

        public SepetController(YemekAPIContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Sepet>>> GetSepets()
        {
            if (_dbContext.Sepets == null)
            {
                return NotFound();
            }

            return await _dbContext.Sepets.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Sepet>> GetSepets(int id)
        {
            if (_dbContext.Sepets == null)
            {
                return NotFound();
            }

            var sepet = await _dbContext.Sepets.FindAsync(id);

            if (sepet == null)
            {
                return NotFound();
            }

            return sepet;
        }

        [HttpPost]
        public async Task<ActionResult<Sepet>> PostSepet(string UserId, string UrunAdet, string Tutar)
        {
            if (!int.TryParse(UserId, out int parsedUserId))
            {
                return BadRequest("Invalid SepetId.");
            }

            if (!int.TryParse(UrunAdet, out int parsedUrunAdet))
            {
                return BadRequest("Invalid UserId.");
            }

            if (!int.TryParse(Tutar, out int parsedTutar))
            {
                return BadRequest("Invalid UserId.");
            }

            Sepet sepet = new()//sepet
            {
                UserId = parsedUserId,
                UrunAdet = parsedUrunAdet,
                Tutar = parsedTutar
            };

            _dbContext.Sepets.Add(sepet);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSepets), new { id = sepet.UserId }, sepet);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Sepet>> PutAdress(int id, int UrunAdet, int Tutar)
        {
            if (UrunAdet == default)//(int)
            {
                return BadRequest("Gerekli alanlar eksik.");
            }

            if (Tutar == default)//(int)
            {
                return BadRequest("Gerekli alanlar eksik.");
            }

            var existingSepet = await _dbContext.Sepets.FindAsync(id);

            if (existingSepet == null)
            {
                return NotFound();
            }

            existingSepet.UrunAdet = UrunAdet;
            existingSepet.Tutar = Tutar;

            await _dbContext.SaveChangesAsync();

            return existingSepet;
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var sepet = await _dbContext.Sepets.FindAsync(id);

            if (sepet == null)
            {
                return NotFound("In correct customer id");
            }

            _dbContext.Sepets.Remove(sepet);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

    }
}
