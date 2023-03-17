using ExaminationSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExaminationSytem
{
    public partial class STA : Form
    {
        DataContext context = new DataContext();
        public STA()
        {
            InitializeComponent();
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void STA_Load(object sender, EventArgs e)
        {
            ComboBoxInstructors.SelectedIndex = -1;
            int courseid = context.Courses.Where(c => c.Instructor.Username == LoginForm.CurrentUserName).Select(i => i.Id).FirstOrDefault();
            //Fill Combo Box With Insructors
            var exam = context.Exams.Where(i=>i.CourseId.Id==courseid).Select(i => i.Id).ToList();

            //Fill the DataTable with records from Table.
            DataTable dt = new DataTable();
            ComboBoxInstructors.DataSource = exam;

            ////Assign DataTable as DataSource.
            //ComboBoxInstructors.DisplayMember = "FName";
            //ComboBoxInstructors.ValueMember = "Id";

            var query2 = context.StExams.Select(s => s.ExId).Distinct();
            var query = context.StExams.Select(s => s.StId).Distinct();
            Dictionary<int, int?> stscore = new Dictionary<int, int?>();

            foreach (var item in query)
            {
                var stname = context.Students.Where(s => s.Id == item).Select(s => s.Id).FirstOrDefault();

                    var stexam = context.StExams.Where(s => s.StId == item).Where(s => s.ExId == 1).Select(s => s.StScore);
                    var result = stexam.Sum();
                    stscore.Add(stname, result);

            }
           var dict = stscore.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            //try
            //{
            //    for (int i = 0; i < 4; i++)
            //    {
            //    var name= dict.ElementAt(i).Key;
            //    var stname = context.Students.Where(s => s.Id == name).Select(s => s.FName).FirstOrDefault();
            //    var score= dict.ElementAt(i).Value;
            //    chartSt.Series["Student"].Points.AddXY(stname, score);
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("there is no result");
            //}
        }

        private void ComboBoxInstructors_SelectedIndexChanged(object sender, EventArgs e)
        {
            chartSt.Series["Student"].Points.Clear();
            var query2 = context.StExams.Select(s => s.ExId).Distinct();
            var query = context.StExams.Select(s => s.StId).Distinct();
            Dictionary<int, int?> stscore = new Dictionary<int, int?>();

            foreach (var item in query)
            {
                var stname = context.Students.Where(s => s.Id == item).Select(s => s.Id).FirstOrDefault();

                var stexam = context.StExams.Where(s => s.StId == item).Where(s => s.ExId == (int)ComboBoxInstructors.SelectedItem).Select(s => s.StScore);
                var result = stexam.Sum();
                stscore.Add(stname, result);

            }
            var dict = stscore.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            try
            {
                if (query.Count() < 4)
                {
                    for (int i = 0; i < query.Count(); i++)
                    {
                        var name = dict.ElementAt(i).Key;
                        var stname = context.Students.Where(s => s.Id == name).Select(s => s.FName).FirstOrDefault();
                        var score = dict.ElementAt(i).Value;
                        chartSt.Series["Student"].Points.AddXY(stname, score);
                    }
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        var name = dict.ElementAt(i).Key;
                        var stname = context.Students.Where(s => s.Id == name).Select(s => s.FName).FirstOrDefault();
                        var score = dict.ElementAt(i).Value;
                        chartSt.Series["Student"].Points.AddXY(stname, score);
                    }
                }
            }
            catch
            {
                MessageBox.Show("there is no result");
            }
        }
    }
}
