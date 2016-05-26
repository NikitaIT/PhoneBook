using System.Collections.Generic;
using System.Web.Mvc;
using Phonebook.Models;
using System.Linq;
namespace Phonebook.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        private PersonDbContext PersonDb = new PersonDbContext();

        public ActionResult Index(string searchString)
        {
            // ДО СОРТИРОВКИ
            // получаем из бд все объекты Person
            // IEnumerable<Person> persons = PersonDb.Persons;
            // передаем все объекты в динамическое свойство Persons в ViewBag
            // ViewBag.Persons = persons;
            // возвращаем представление
            // return View();
            var persons = from person in PersonDb.Persons
                          select person;
            if (!string.IsNullOrEmpty(searchString))
            {
                persons = persons.Where(
                    person => person.Name.ToUpper().Contains(searchString.ToUpper()) 
                           || person.Surname.ToUpper().Contains(searchString.ToUpper())
                           || person.Patronymic.ToUpper().Contains(searchString.ToUpper())
                           || person.PhoneNumber.ToUpper().Contains(searchString.ToUpper())
                           || person.SkypeLogin.ToUpper().Contains(searchString.ToUpper()));
            }
            ViewBag.Persons = persons.ToList();
            return View();
        }
    }
}