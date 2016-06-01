using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Phonebook.Models;
namespace Phonebook.Controllers
{
    public class NotesController : ApiController
    {
        //GET: Person
        public List<Person> Get()
        {
            var list = new List<Person>
            {
                new Person { Id=1, Surname ="АК", Name = "Витя", Patronymic = "Сергеевич", SkypeLogin = "edfds23df", PhoneNumber =
                "4123413241234", Mail = "edfds23df", Password = "edfds23df", Date = DateTime.UtcNow,Plase = "54.98, 82.89", PlaseName = "Жопа"}
            };
            return list;
        }
    }
}
