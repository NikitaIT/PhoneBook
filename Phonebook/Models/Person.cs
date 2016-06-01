using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Phonebook.Models
{
    public class Person
    {
        // ID сотрудника
        public int Id { get; set; }
        // пароль
        public string Password { get; set; }
        // ФИО(SNP) сотрудника
            public string Surname { get; set; }
            public string Name { get; set; }
            public string Patronymic { get; set; }
        // скайп
        public string SkypeLogin { get; set; }
        // номер телефона
        public string PhoneNumber { get; set; }
        // почта
        public string Mail { get; set; }
        public string Plase { get; set; }
        public string PlaseName { get; set; }
        // дата внесения в реест
        public DateTime Date { get; set; }
    }
    public class PersonDbContext : DbContext
    {
        //добавление персон
        public DbSet<Person> Persons { get; set; }
    }
    public class PersonDbInitializer : DropCreateDatabaseAlways<PersonDbContext>
    {
        protected override void Seed(PersonDbContext db)
        {
            db.Persons.Add(new Person { Id=1, Surname ="АК", Name = "Витя", Patronymic = "Сергеевич", SkypeLogin = "edfds23df", PhoneNumber = "4123413241234", Mail = "edfds23df", Password = "edfds23df", Date = DateTime.UtcNow,Plase = "54.98, 82.89", PlaseName = "Жопа" });
            db.Persons.Add(new Person { Id = 2, Surname = "Ларин", Name = "Паша", Patronymic = "Кузьмич", SkypeLogin = "asdf", PhoneNumber = "4123413241234", Mail = "asdffaaf", Password = "asdfasdf", Date = DateTime.UtcNow, Plase = "52.98, 82.19", PlaseName = "Пермь" });
            db.Persons.Add(new Person { Id = 3, Surname = "Хованский", Name = "Саша", Patronymic = "Орлович", SkypeLogin = "qweqw", PhoneNumber = "4123413241234", Mail = "asdfasf", Password = "adfaf", Date = DateTime.UtcNow, Plase = "54.98, 82.39", PlaseName = "Тагил" });
            db.Persons.Add(new Person { Id = 4, Surname = "йцук", Name = "Вцаупцу", Patronymic = "выаывач", SkypeLogin = "sferf23", PhoneNumber = "4123413241234", Mail = "asdf", Password = "adfasdf", Date = DateTime.UtcNow, Plase = "54.98, 82.82", PlaseName = "Голень" });
            db.Persons.Add(new Person { Id = 5, Surname = "Ларийуцк", Name = "цкпца", Patronymic = "цукпцк", SkypeLogin = "qwefqef", PhoneNumber = "4123413241234", Mail = "asddfs", Password = "asdfasdf", Date = DateTime.UtcNow, Plase = "54.98, 12.89", PlaseName = "Жопа" });
            db.Persons.Add(new Person { Id = 6, Surname = "Хуйцанский", Name = "укпцша", Patronymic = "лукцувичц", SkypeLogin = "xcvasd", PhoneNumber = "4123413241234", Mail = "asdfasdf", Password = "asdfasdf", Date = DateTime.UtcNow, Plase = "54.98, 82.89", PlaseName = "Жопа" });

            base.Seed(db);
        }
    }
}
