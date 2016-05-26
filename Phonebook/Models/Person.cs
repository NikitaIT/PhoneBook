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
            db.Persons.Add(new Person { Id=1, Surname ="АК", Name = "Витя", Patronymic = "Сергеевич", SkypeLogin = "edfds23df", PhoneNumber = "4123413241234", Mail = "edfds23df", Password = "edfds23df", Date = DateTime.UtcNow });
            db.Persons.Add(new Person { Id = 2, Surname = "Ларин", Name = "Паша", Patronymic = "Кузьмич", SkypeLogin = "asdf", PhoneNumber = "4123413241234", Mail = "edfds23df", Password = "edfds23df", Date = DateTime.UtcNow });
            db.Persons.Add(new Person { Id = 3, Surname = "Хованский", Name = "Саша", Patronymic = "Орлович", SkypeLogin = "qweqw", PhoneNumber = "4123413241234", Mail = "edfds23df", Password = "edfds23df", Date = DateTime.UtcNow });

            base.Seed(db);
        }
    }
}
