using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace diplom2
{
    public class TimeTables
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SerialNumberLectures { get; set; }
        public string LessonName { get; set; }
        public string LessonTeacher { get; set; }
        public string Room { get; set; }
        public string Week { get; set; }
        public string Group { get; set; }
    }
}
