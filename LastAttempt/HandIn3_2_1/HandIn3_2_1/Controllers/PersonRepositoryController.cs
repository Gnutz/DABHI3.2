using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HandIn3_2_1.Models;
using HandIn3_2_1.Repository;

namespace HandIn3_2_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonRepositoryController : ControllerBase
    {
        private readonly E18I4DABau569735Context _context;
        private readonly IRepository<Person> Repository_;
        private readonly IUnitOfWork UnitOfWork_;

        public PersonRepositoryController(E18I4DABau569735Context context)
        {
            _context = context;
            Repository_ = new Repository<Person>(context);
            UnitOfWork_ = new UnitOfWork(context);

        }

        // GET: api/PersonRepository
        [HttpGet]
        public IEnumerable<Person> GetPerson()
        {
            return Repository_.GetAll();
        }

        // GET: api/PersonRepository/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person =  Repository_.Get(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/PersonRepository/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson([FromRoute] long id, [FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.PersonId)
            {
                return BadRequest();
            }

            Repository_.Update(person);
            UnitOfWork_.Complete();

            return NoContent();
        }

        // POST: api/PersonRepository
        [HttpPost]
        public async Task<IActionResult> PostPerson([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Repository_.Add(person);
            UnitOfWork_.Complete();

            return CreatedAtAction("GetPerson", new { id = person.PersonId }, person);
        }

        // DELETE: api/PersonRepository/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            Repository_.Remove(person);
            UnitOfWork_.Complete();

            return Ok(person);
        }

    }
}