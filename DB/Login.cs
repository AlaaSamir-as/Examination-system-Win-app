using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class Login
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public virtual List<Manager> managers { get; set; }
        public virtual List<Instructor> instructors { get; set; }
        public virtual List<Student> students { get; set; }
    }
}
