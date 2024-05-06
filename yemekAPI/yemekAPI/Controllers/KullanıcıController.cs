using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yemekAPI.Models;

namespace yemekAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullanıcıController : ControllerBase
    {
        private readonly YemekAPIContext _dbContext;

        public KullanıcıController(YemekAPIContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Kullanıcı>>> GetKullanıcıs()
        {
            if (_dbContext.Kullanıcıs == null)
            {
                return NotFound();
            }

            return await _dbContext.Kullanıcıs.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Kullanıcı>> GetKullanıcıs(int id)
        {
            if (_dbContext.Kullanıcıs == null)
            {
                return NotFound();
            }

            var kullanıcı = await _dbContext.Kullanıcıs.FindAsync(id);

            if (kullanıcı == null)
            {
                return NotFound();
            }

            return kullanıcı;
        }

        [HttpPost]
        public async Task<ActionResult<Kullanıcı>> PostKullanıcı(string ad, string soyad, string email, string AdresId, string Tel)
        {
            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(Tel))
            {
                return BadRequest("Required fields are missing.");
            }

            if (!int.TryParse(AdresId, out int parsedAdresId))
            {
                return BadRequest("Invalid UserId.");
            }

            Kullanıcı kullanıcı = new()//kullanıcı
            {
                Ad = ad,
                Soyad = soyad,
                Email = email,
                Tel = Tel,
                AdresId = parsedAdresId
            };

            _dbContext.Kullanıcıs.Add(kullanıcı);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetKullanıcıs), new { id = kullanıcı.UserId }, kullanıcı);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Kullanıcı>> PutKullanıcı(int id, string ad, string soyad, string email, int AdresId, string Tel)
        {
            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(Tel))
            {
                return BadRequest("Required fields are missing.");
            }

            /*if (AdresId == default)//(int)
            {
                return BadRequest("Gerekli alanlar eksik.");
            }*/

            var existingKullanıcı = await _dbContext.Kullanıcıs.FindAsync(id);

            if (existingKullanıcı == null)
            {
                return NotFound();
            }

            existingKullanıcı.Ad = ad;
            existingKullanıcı.Soyad = soyad;
            existingKullanıcı.Email = email;
            existingKullanıcı.Tel = Tel;
            existingKullanıcı.AdresId = AdresId;

            await _dbContext.SaveChangesAsync();

            return existingKullanıcı;
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
        var kullanıcı = await _dbContext.Kullanıcıs.FindAsync(id);

        if (kullanıcı == null)
        {
            return NotFound("In correct customer id");
        }

        _dbContext.Kullanıcıs.Remove(kullanıcı);
        await _dbContext.SaveChangesAsync();

        return Ok();
        }

    }
}

