using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhonStore.Data;
using PhonStore.Models;

namespace PhonStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CosherPhonesController : ControllerBase
    {
        private readonly PhoneStoreDB _context;

        public CosherPhonesController(PhoneStoreDB context)
        {
            _context = context;
        }

        // GET: api/CosherPhones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CosherPhone>>> GetcosherPhones()
        {
            return await _context.cosherPhones.ToListAsync();
        }

        // GET: api/CosherPhones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CosherPhone>> GetCosherPhone(int id)
        {
            var cosherPhone = await _context.cosherPhones.FindAsync(id);

            if (cosherPhone == null)
            {
                return NotFound();
            }

            return cosherPhone;
        }

        // PUT: api/CosherPhones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCosherPhone(int id, CosherPhone cosherPhone)
        {
            if (id != cosherPhone.Id)
            {
                return BadRequest();
            }

            _context.Entry(cosherPhone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CosherPhoneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CosherPhones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CosherPhone>> PostCosherPhone(CosherPhone cosherPhone)
        {
            _context.cosherPhones.Add(cosherPhone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCosherPhone", new { id = cosherPhone.Id }, cosherPhone);
        }

        // DELETE: api/CosherPhones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCosherPhone(int id)
        {
            var cosherPhone = await _context.cosherPhones.FindAsync(id);
            if (cosherPhone == null)
            {
                return NotFound();
            }

            _context.cosherPhones.Remove(cosherPhone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CosherPhoneExists(int id)
        {
            return _context.cosherPhones.Any(e => e.Id == id);
        }
    }
}
