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
    public class UnCosherPhonesController : ControllerBase
    {
        private readonly PhoneStoreDB _context;

        public UnCosherPhonesController(PhoneStoreDB context)
        {
            _context = context;
        }

        // GET: api/UnCosherPhones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnCosherPhone>>> GetunCosherPhones()
        {
            return await _context.unCosherPhones.ToListAsync();
        }

        // GET: api/UnCosherPhones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnCosherPhone>> GetUnCosherPhone(int id)
        {
            var unCosherPhone = await _context.unCosherPhones.FindAsync(id);

            if (unCosherPhone == null)
            {
                return NotFound();
            }

            return unCosherPhone;
        }

        // PUT: api/UnCosherPhones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnCosherPhone(int id, UnCosherPhone unCosherPhone)
        {
            if (id != unCosherPhone.Id)
            {
                return BadRequest();
            }

            _context.Entry(unCosherPhone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnCosherPhoneExists(id))
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

        // POST: api/UnCosherPhones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UnCosherPhone>> PostUnCosherPhone(UnCosherPhone unCosherPhone)
        {
            _context.unCosherPhones.Add(unCosherPhone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnCosherPhone", new { id = unCosherPhone.Id }, unCosherPhone);
        }

        // DELETE: api/UnCosherPhones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnCosherPhone(int id)
        {
            var unCosherPhone = await _context.unCosherPhones.FindAsync(id);
            if (unCosherPhone == null)
            {
                return NotFound();
            }

            _context.unCosherPhones.Remove(unCosherPhone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnCosherPhoneExists(int id)
        {
            return _context.unCosherPhones.Any(e => e.Id == id);
        }
    }
}
