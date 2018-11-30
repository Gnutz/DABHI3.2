using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HandIn3_2_1.Models;

namespace HandIn3_2_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailAddressesController : ControllerBase
    {
        private readonly PersonCatalogueCORECOntext _context;

        public EmailAddressesController(PersonCatalogueCORECOntext context)
        {
            _context = context;
        }

        // GET: api/EmailAddresses
        [HttpGet]
        public IEnumerable<EmailAddress> GetEmailAddresses()
        {
            return _context.EmailAddresses;
        }

        // GET: api/EmailAddresses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmailAddress([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emailAddress = await _context.EmailAddresses.FindAsync(id);

            if (emailAddress == null)
            {
                return NotFound();
            }

            return Ok(emailAddress);
        }

        // PUT: api/EmailAddresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmailAddress([FromRoute] int id, [FromBody] EmailAddress emailAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emailAddress.EmailAddressId)
            {
                return BadRequest();
            }

            _context.Entry(emailAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailAddressExists(id))
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

        // POST: api/EmailAddresses
        [HttpPost]
        public async Task<IActionResult> PostEmailAddress([FromBody] EmailAddress emailAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EmailAddresses.Add(emailAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmailAddress", new { id = emailAddress.EmailAddressId }, emailAddress);
        }

        // DELETE: api/EmailAddresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmailAddress([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emailAddress = await _context.EmailAddresses.FindAsync(id);
            if (emailAddress == null)
            {
                return NotFound();
            }

            _context.EmailAddresses.Remove(emailAddress);
            await _context.SaveChangesAsync();

            return Ok(emailAddress);
        }

        private bool EmailAddressExists(int id)
        {
            return _context.EmailAddresses.Any(e => e.EmailAddressId == id);
        }
    }
}