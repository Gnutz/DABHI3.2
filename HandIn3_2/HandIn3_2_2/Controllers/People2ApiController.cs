using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using PersonCatalogueDocumentModel;

namespace HandIn3_2_2.Controllers
{
    [Produces("application/json")]
    [Route("api/People")]
    public class People2ApiController : Controller
    {
        private readonly IPersonCatalogueRepository<Person> Repository;

        public People2ApiController(IPersonCatalogueRepository<Person> repository)
        {
            this.Repository = repository;
        }

        
        // GET: api/People
        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        {
            var people = await Repository.GetPersonsAsync();

            return people;
        }

        // GET: api/People/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult> Get(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Person person = await Repository.GetPersonAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // POST: api/People
        [HttpPost]
        public async Task<ActionResult> Post([Bind("Id, FirstName, MiddleName, Surname, Address, EmailAddress")] Person person)
        {

            if (ModelState.IsValid)
            {
                var newPerson = await Repository.CreatePersonAsync(person);
                return Ok((Person) (dynamic) newPerson);
            }

            return View(person);
        }

        // PUT: api/People/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute]  string id, [FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != person.Id)
            {
                return BadRequest();
            }
            try
            {
                await Repository.UpdatePersonAsync(id, person);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return NotFound();
                else throw;
            }
            catch (Exception)
            {
                throw;
            }

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Person person = await Repository.GetPersonAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }
    }
}
