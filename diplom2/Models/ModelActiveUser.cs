using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace diplom2.Models
{
    public class ModelActiveUser//:NinjectModule 
    {
        public string firstName;
        public string lastName;
        public string accountNumber;
        public string email;
        public DateTime dob;
        public string groupName;

        //public override void Load()
        //{
        //    Bind<IActiveUser>().To<ModelActiveUser>();
        //}

        public ModelActiveUser(string accNumb)
        {
            firstName = Startup.db.UserTables.Where(t => t.AccountNumber == accNumb).First().FirstName;
            lastName = Startup.db.UserTables.Where(t => t.AccountNumber == accNumb).First().LastName;
            accountNumber = Startup.db.UserTables.Where(t => t.AccountNumber == accNumb).First().AccountNumber;
            email = Startup.db.UserTables.Where(t => t.AccountNumber == accNumb).First().Email;
            dob = Startup.db.UserTables.Where(t => t.AccountNumber == accNumb).First().Dob;
            groupName = Startup.db.UserTables.Where(t => t.AccountNumber == accNumb).First().GroupName;
        }

        //public string FirstName => firstName;
        //public string LastName => lastName;
        //public string AccountNumber => accountNumber;
        //public string Email => email;
        //public DateTime DOB => dob;
        //public string GroupName => groupName;

        
    }
}
