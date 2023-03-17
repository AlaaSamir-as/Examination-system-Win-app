using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class StExam
    {
        public int StId { get; set; }
        public int ExId { get; set; }
        [ForeignKey("QuestionPool")]
        public int QId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual QuestionPool QuestionPool { get; set; }
        public string StAnswer { get; set; }
        public int? StScore { get; set; }
        

    }
}
