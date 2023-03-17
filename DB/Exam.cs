using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class Exam
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int? TotalTime { get; set; }
        public Instructor InstructorId { get; set; }
        public Course CourseId { get; set; }
        public virtual List<QuestionPool> questionsId { get; set; }
        public virtual List<StExam> students { get; set; }
    }
}
