using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class Instructor
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }


        //public int? ManagerId { get; set; }
        //[ForeignKey("ManagerId")]
        //public Manager Manager { get; set; }

        public string Username { get; set; }
        [ForeignKey("Username")]
        public Login Login { get; set; }
        //public Manager ManagerId { get; set; }
        public int ManagerId { get; set; }
        public virtual List<Student> students { get; set; }
        public virtual List<Course> courses { get; set; }
        public virtual List<Exam> exams { get; set; }
    }
}
