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
        // создаем список взаимодействия  
        private List<int> IdPersonsWhoAdded = new List<int> {-1,-2};
        /* Index - инициализация страницы
         * searchString - Выборка по запросу
         * Index - место операции
         */
        public ActionResult Index(string searchString)
        {
            ViewBag.IdPersonsWhoAdded = IdPersonsWhoAdded;
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

            return View("Index");
        }
        /* AddToEList - HttpGet добавление элемента
         * id - номер добавляемого элемента
         * Index - место операции
         */
        [HttpGet]
        public ActionResult AddToEList(int id)
        {
            if(IdPersonsWhoAdded.Any(i => i == id))
            {
                IdPersonsWhoAdded.Remove(id);
            }
            else IdPersonsWhoAdded.Add(id);
            ViewBag.IdPersonsWhoAdded = IdPersonsWhoAdded;
            return View("Index");
        }
        /* 
        /* RemoveToEList - HttpGet удаление элемента
         * id - номер удаляемого элемента
         * Index - место операции
         */
        /* 
       [HttpGet]
       public ActionResult RemoveToEList(int id)
       {
           IdPersonsWhoAdded.Remove(id);
           ViewBag.IdPersonsWhoAdded = IdPersonsWhoAdded;
           return View("Index");
       }
       */
        /*[HttpPost]
        public string AddToEList(Persons Person)
        {
            
        }*/
    }
}