using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yemekAPI.Models;

namespace yemekAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SepetUrunController : ControllerBase
    {
        private readonly YemekAPIContext _dbContext;

        public SepetUrunController(YemekAPIContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<SepetUrun>>> GetSepetUruns()
        {
            if (_dbContext.SepetUruns == null)
            {
                return NotFound();
            }

            return await _dbContext.SepetUruns.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<SepetUrun>> GetsepetUruns(int id)
        {
            if (_dbContext.SepetUruns == null)
            {
                return NotFound();
            }

            var sepetUrun = await _dbContext.SepetUruns.FindAsync(id);

            if (sepetUrun == null)
            {
                return NotFound();
            }

            return sepetUrun;
        }

        [HttpPost]
        public async Task<ActionResult<SepetUrun>> PostSepetUrun(string UrunId, string SepetId)
        {
            if (!int.TryParse(UrunId, out int parsedUrunId))
            {
                return BadRequest("Invalid UserId.");
            }

            if (!int.TryParse(SepetId, out int parsedSepetId))
            {
                return BadRequest("Invalid UserId.");
            }

            SepetUrun sepetUrun = new()//sepetUrun
            {
               UrunId = parsedUrunId,
               SepetId = parsedSepetId
            };

            _dbContext.SepetUruns.Add(sepetUrun);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSepetUruns), new { id = sepetUrun.SepetId }, sepetUrun);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SepetUrun>> PutSepetUrun(int id, int UrunId)
        {
            if (UrunId == default)//(int)
            {
                return BadRequest("Gerekli alanlar eksik.");
            }

            var existingSepetUrun = await _dbContext.SepetUruns.FindAsync(id);

            if (existingSepetUrun == null)
            {
                return NotFound();
            }

            existingSepetUrun.UrunId = UrunId;

            await _dbContext.SaveChangesAsync();

            return existingSepetUrun;
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var sepetUrun = await _dbContext.SepetUruns.FindAsync(id);

            if (sepetUrun == null)
            {
                return NotFound("In correct customer id");
            }

            _dbContext.SepetUruns.Remove(sepetUrun);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

    }
}
