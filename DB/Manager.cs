using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class Manager
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public string Username { get; set; }
        public virtual List<Instructor> instructors { get; set; }
        public virtual List<Student> students { get; set; }
    }
}
