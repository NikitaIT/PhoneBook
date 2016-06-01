using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Phonebook.Models
{
    public class Admin : Person
    {
        int iOpenKey = 3;
        int iSicretKey = 6111579;
        int iN = 9173503;
        public int iPassword;
        public void gPassword(int iM) { iPassword = (iM ^ iOpenKey)%iN; }
    }
    public class AdminDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
    }
    public class AdminDbInitializer : DropCreateDatabaseAlways<AdminDbContext>
    {
        protected override void Seed(AdminDbContext db)
        {
            db.Admins.Add(new Admin { Id = 1, Surname = "АК", Name = "Витя", Patronymic = "Сергеевич", SkypeLogin = "edfds23df", PhoneNumber = "4123413241234", Mail = "edfds23df", Password = "edfds23df", Date = DateTime.UtcNow, Plase = "54.98, 82.89", PlaseName = "Жопа" });
            base.Seed(db);
        }
    }
}