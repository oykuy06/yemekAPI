using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yemekAPI.Models;

namespace yemekAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorilerController : ControllerBase
    {
        private readonly YemekAPIContext _dbContext;

        public KategorilerController(YemekAPIContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Kategoriler>>> GetKategorilers()
        {
            if (_dbContext.Kategorilers == null)
            {
                return NotFound();
            }

            return await _dbContext.Kategorilers.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Kategoriler>> GetKategorilers(int id)
        {
            if (_dbContext.Kategorilers == null)
            {
                return NotFound();
            }

            var kategoriler = await _dbContext.Kategorilers.FindAsync(id);

            if (kategoriler == null)
            {
                return NotFound();
            }

            return kategoriler;
        }

        [HttpPost]
        public async Task<ActionResult<Kategoriler>> PostKategoriler(string KategoriTuru)
        {
            if (string.IsNullOrEmpty(KategoriTuru))
            {
                return BadRequest("Required fields are missing.");
            }

            Kategoriler kategoriler = new()//kategoriler
            {
                KategoriTuru = KategoriTuru
            };

            _dbContext.Kategorilers.Add(kategoriler);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetKategorilers), new { id = kategoriler.KategoriId }, kategoriler);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Kategoriler>> PutKategoriler(int id, string KategoriTuru)
        {
            if (string.IsNullOrEmpty(KategoriTuru))
            {
                return BadRequest("Required fields are missing.");
            }

            var existingKategoriler = await _dbContext.Kategorilers.FindAsync(id);

            if (existingKategoriler == null)
            {
                return NotFound();
            }

            existingKategoriler.KategoriTuru = KategoriTuru;

            await _dbContext.SaveChangesAsync();

            return existingKategoriler;
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var kategoriler = await _dbContext.Kategorilers.FindAsync(id);

            if (kategoriler == null)
            {
                return NotFound("In correct customer id");
            }

            _dbContext.Kategorilers.Remove(kategoriler);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
