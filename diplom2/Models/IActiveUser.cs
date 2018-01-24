using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace diplom2.Models
{
    interface IActiveUser
    {
        string FirstName { get;  }
        string LastName { get;  }
        string AccountNumber { get; }
        string Email { get; }
        DateTime DOB { get; }
        string GroupName { get; }

        //void SetModel(ModelActiveUser modelActiveUser);
    }
}
