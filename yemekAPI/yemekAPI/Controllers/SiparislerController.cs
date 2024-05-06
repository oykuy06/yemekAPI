using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yemekAPI.Models;

namespace yemekAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiparislerController : ControllerBase
    {
        private readonly YemekAPIContext _dbContext;

        public SiparislerController(YemekAPIContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Siparisler>>> GetSiparislers()
        {
            if (_dbContext.Siparislers == null)
            {
                return NotFound();
            }

            return await _dbContext.Siparislers.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Siparisler>> GetSiparislers(int id)
        {
            if (_dbContext.Siparislers == null)
            {
                return NotFound();
            }

            var siparisler = await _dbContext.Siparislers.FindAsync(id);

            if (siparisler == null)
            {
                return NotFound();
            }

            return siparisler;
        }

        [HttpPost]
        public async Task<ActionResult<Siparisler>> PostSiparisler(string UserId, string SiparisAdet, string SiparisTutar, string RestaurantId)
        {            
            if (!int.TryParse(UserId, out int parsedUserId))
            {
                return BadRequest("Invalid UserId.");
            }

            if (!int.TryParse(SiparisAdet, out int parsedSiparisAdet))
            {
                return BadRequest("Invalid UserId.");
            }

            if (!int.TryParse(SiparisTutar, out int parsedSiparisTutar))
            {
                return BadRequest("Invalid UserId.");
            }

            if (!int.TryParse(RestaurantId, out int parsedRestaurantId))
            {
                return BadRequest("Invalid UserId.");
            }

            Siparisler siparisler = new()//siparisler
            {
                UserId = parsedUserId,
                SiparisAdet = parsedSiparisAdet,
                SiparisTutar = parsedSiparisTutar,
                RestaurantId = parsedRestaurantId
            };

            _dbContext.Siparislers.Add(siparisler);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSiparislers), new { id = siparisler.SiparisId }, siparisler);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Siparisler>> PutSiparisler(int id, int UserId, int SiparisAdet, int SiparisTutar, int RestaurantId)
        {
            if (UserId == default)//(int)
            {
                return BadRequest("Gerekli alanlar eksik.");
            }

            if (SiparisAdet == default)//(int)
            {
                return BadRequest("Gerekli alanlar eksik.");
            }

            if (SiparisTutar == default)//(int)
            {
                return BadRequest("Gerekli alanlar eksik.");
            }

            if (RestaurantId == default)//(int)
            {
                return BadRequest("Gerekli alanlar eksik.");
            }

            var existingSiparisler = await _dbContext.Siparislers.FindAsync(id);

            if (existingSiparisler == null)
            {
                return NotFound();
            }

            existingSiparisler.UserId = UserId;
            existingSiparisler.SiparisAdet = SiparisAdet;
            existingSiparisler.SiparisTutar = SiparisTutar;
            existingSiparisler.RestaurantId = RestaurantId;

            await _dbContext.SaveChangesAsync();

            return existingSiparisler;
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var siparisler = await _dbContext.Siparislers.FindAsync(id);

            if (siparisler == null)
            {
                return NotFound("In correct customer id");
            }

            _dbContext.Siparislers.Remove(siparisler);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

    }
}
