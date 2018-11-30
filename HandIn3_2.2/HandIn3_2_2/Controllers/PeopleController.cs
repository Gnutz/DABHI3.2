using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HandIn3_2_2.Models;
using PersonCatalogueDocumentModel;

namespace HandIn3_2_2.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPersonCatalogueRepository<Person> Respository;
        public PeopleController(IPersonCatalogueRepository<Person> Respository)
        {
            this.Respository = Respository;
        }

        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            var persons = await Respository.GetPersonsAsync();
            return View(persons);
        }


#pragma warning disable 1998
        [ActionName("Create")]
        public async Task<IActionResult> CreateAsync()
        {
            return View();
        }
#pragma warning restore 1998

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind("PersonId, FirstName, MiddleName, Surname, Address, EmailAddresses")] Person person)
        {
            if (ModelState.IsValid)
            {
                await Respository.CreatePersonAsync(person);
                return RedirectToAction("Index");
            }

            return View(person);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind("Id, FirstName, MiddleName, Surname, Address, EmailAddresses")] Person  person)
        {
            if (ModelState.IsValid)
            {
                await Respository.UpdatePersonAsync(person.Id, person);
                return RedirectToAction("Index");
            }

            return View(person);
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Person person  = await Respository.GetPersonAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Person person = await Respository.GetPersonAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind("PersonId")] string id)
        {
            await Respository.DeletePersonAsync(id);
            return RedirectToAction("Index");
        }

        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(string id)
        {
            Person person = await Respository.GetPersonAsync(id);
            return View(person);
        }
    }
}
