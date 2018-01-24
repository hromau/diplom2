using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace diplom2
{
    public class TableOfStatements
    {
        [Key]
        public string AccountNumber { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string TypeOfStatement { get; set; }
        public bool Verification { get; set; }
    }
}
