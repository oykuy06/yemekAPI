using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yemekAPI.Models;

namespace yemekAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenülerController : ControllerBase
    {
        private readonly YemekAPIContext _dbContext;

        public MenülerController(YemekAPIContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Menüler>>> GetMenülers()
        {
            if (_dbContext.Menülers == null)
            {
                return NotFound();
            }

            return await _dbContext.Menülers.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Menüler>> GetMenülers(int id)
        {
            if (_dbContext.Menülers == null)
            {
                return NotFound();
            }

            var menüler = await _dbContext.Menülers.FindAsync(id);

            if (menüler == null)
            {
                return NotFound();
            }

            return menüler;
        }
        [HttpPost]
        public async Task<ActionResult<Menüler>> PostMenüler(string UrunId)
        {
            if (string.IsNullOrEmpty(UrunId))
            {
                return BadRequest("Required fields are missing.");
            }

            if (!int.TryParse(UrunId, out int parsedUrunId))
            {
                return BadRequest("Invalid AdresId.");
            }

            Menüler menüler = new()//menüler
            {
                UrunId = parsedUrunId
            };

            _dbContext.Menülers.Add(menüler);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMenülers), new { id = menüler.UrunId }, menüler);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Menüler>> PutMenüler(int id, int MenuId)
        {
            if (MenuId == default)//(int)
            {
                return BadRequest("Gerekli alanlar eksik.");
            }

            var existingMenüler = await _dbContext.Menülers.FindAsync(id);

            if (existingMenüler == null)
            {
                return NotFound();
            }

            existingMenüler.MenuId = MenuId;

            await _dbContext.SaveChangesAsync();

            return existingMenüler;
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var menüler = await _dbContext.Menülers.FindAsync(id);

            if (menüler == null)
            {
                return NotFound("In correct customer id");
            }

            _dbContext.Menülers.Remove(menüler);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

    }
}
