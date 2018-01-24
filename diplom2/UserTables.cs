using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace diplom2
{
    public class UserTables
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key]
        public string AccountNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public string GroupName { get; set; }
    }
}
