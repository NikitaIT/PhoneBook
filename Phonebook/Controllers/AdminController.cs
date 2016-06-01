using Phonebook.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Phonebook.Controllers
{
    public class AdminController : Controller
    {
        public PersonDbContext PersonDb = new PersonDbContext();
        // создаем список взаимодействия  
        public List<int> IdPersonsWhoAdded = new List<int> {1,2,3};
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.IdPersonsWhoAdded = IdPersonsWhoAdded;
            ViewBag.Persons = PersonDb.Persons.ToList();
            return View("Index");
        }
        [HttpGet]
        public ActionResult AddToEList(int id)
        {
            if (IdPersonsWhoAdded.Any(i => i == id))
            {
                IdPersonsWhoAdded.Remove(id);
            }
            else IdPersonsWhoAdded.Add(id);
            ViewBag.IdPersonsWhoAdded = IdPersonsWhoAdded;
            return View("Index");
        }
        public ViewResult Details(int id)
        {
            Person person = PersonDb.Persons.Find(id);
            return View(person);
        }
        [HttpPost]
        public ActionResult Create(Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PersonDb.Persons.Add(person);
                    PersonDb.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error (add a variable name after DataException) 
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(person);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Person person = PersonDb.Persons.Find(id);
                PersonDb.Persons.Remove(person);
                PersonDb.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                    new System.Web.Routing.RouteValueDictionary {
                { "id", id },
                { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    }
}