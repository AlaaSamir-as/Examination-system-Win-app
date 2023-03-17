using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxDegree { get; set; }
        public int MinDegree { get; set; }
        [ForeignKey("Instructor")]
        public int? InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual List<QuestionPool> questions { get;set; }
        public virtual List<Exam> exams { get;set; }
    }
}
