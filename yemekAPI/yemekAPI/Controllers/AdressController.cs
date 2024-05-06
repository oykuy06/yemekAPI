using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yemekAPI.Models;

namespace yemekAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        private readonly YemekAPIContext _dbContext;

        public AdressController(YemekAPIContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Adress>>> GetAdresses()
        {
            if(_dbContext.Adresses == null)
            {
                return NotFound();
            }

            return await _dbContext.Adresses.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Adress>> GetAdresses(int id)
        {
            if (_dbContext.Adresses == null)
            {
                return NotFound();
            }

            var adress = await _dbContext.Adresses.FindAsync(id);

            if(adress == null) 
            {
                return NotFound();
            }

            return adress;
        }

        [HttpPost]
        public async Task<ActionResult<Adress>> PostAdress(string EvAdresi, string IsAdresi)
        {
            if (string.IsNullOrEmpty(EvAdresi) || string.IsNullOrEmpty(IsAdresi))
            {
                return BadRequest("Required fields are missing.");
            }
          
            Adress adress = new()//adress
            {
                EvAdresi = EvAdresi,
                IsAdresi = IsAdresi
            };

            _dbContext.Adresses.Add(adress);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAdresses), new { id = adress.AdresId }, adress);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Adress>> PutAdress(int id, string EvAdresi, string IsAdresi)
        {
            if (string.IsNullOrEmpty(EvAdresi) || string.IsNullOrEmpty(IsAdresi))
            {
                return BadRequest("Required fields are missing.");
            }

            var existingAddress = await _dbContext.Adresses.FindAsync(id);

            if (existingAddress == null)
            {
                return NotFound();
            }

            existingAddress.EvAdresi = EvAdresi;
            existingAddress.IsAdresi = IsAdresi;

            await _dbContext.SaveChangesAsync();

            return existingAddress;
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var adress = await _dbContext.Adresses.FindAsync(id);

            if(adress == null)
            {
                return NotFound("In correct customer id");
            }

            _dbContext.Adresses.Remove(adress);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
