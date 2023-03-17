using ExaminationSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExaminationSytem.InstructorUC
{
    public partial class MakeExam : UserControl
    {
        DataContext dataContext=new DataContext();
        public MakeExam()
        {
            InitializeComponent();
            int courseid = dataContext.Courses.Where(c => c.Instructor.Username == LoginForm.CurrentUserName).Select(i => i.Id).FirstOrDefault();
            dataGridView1.DataSource = dataContext.QuestionPool.Where(i => i.CourseId == courseid).ToList();
            dataGridView1.MultiSelect = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btn_Manual_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 10)
            {
                if (numericUpDown1.Value > 0)
                {
                    int courseid = dataContext.Courses.Where(c => c.Instructor.Username == LoginForm.CurrentUserName).Select(i => i.Id).FirstOrDefault();
                    int? insID = dataContext.Courses.Where(c => c.Instructor.Username == LoginForm.CurrentUserName).Select(i => i.InstructorId).FirstOrDefault();
                    //textBox1.Text = insID.ToString();
                    Course course = dataContext.Courses.Where(c => c.Id == courseid).FirstOrDefault();
                    Instructor ins = dataContext.Instructors.Where(c => c.Username == LoginForm.CurrentUserName).FirstOrDefault();
                    Exam exam = new Exam() { TotalTime = (int)numericUpDown1.Value, CourseId = course, InstructorId = ins };
                    dataContext.Exams.Add(exam);
                    dataContext.SaveChanges();

                    List<QuestionPool> questionPools = new List<QuestionPool>();
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Selected == true)
                        {
                            int QId = (int)dataGridView1.Rows[i].Cells[0].Value;
                            QuestionPool q = dataContext.QuestionPool.FirstOrDefault(c => c.Id == QId);
                            dataContext.Exams.Include("questionsId").FirstOrDefault(x => x.Id == exam.Id).questionsId.Add(q);
                            dataContext.SaveChanges();
                        }
                    }
                    //int Stid = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
                    textBox1.Text = exam.Id.ToString();
                    MessageBox.Show("Exam is assigened successfully");
                }
                else
                {
                    MessageBox.Show("Must determinate time of exam");
                }
            }
            else
            {
                MessageBox.Show("Must select 10 questions");

            }

        }

        private void btn_RandomExam_Click(object sender, EventArgs e)
        {
            int courseid = dataContext.Courses.Where(c => c.Instructor.Username == LoginForm.CurrentUserName).Select(x => x.Id).FirstOrDefault();
            List<int>QIds= dataContext.QuestionPool.Where(x => x.CourseId == courseid).Select(x=>x.Id).ToList();
            Random random= new Random();

            //if (numericUpDown2.Value <= QIds.Count)
            //{

            if (numericUpDown1.Value > 0)
            {
                if (QIds.Count() >= 10)
                {
                    Course course = dataContext.Courses.Where(c=>c.Id==courseid).FirstOrDefault();
                    Instructor ins = dataContext.Instructors.Where(c => c.Username == LoginForm.CurrentUserName).FirstOrDefault();
                    Exam exam =new Exam() {TotalTime= (int)numericUpDown1.Value,CourseId=course,InstructorId=ins};
                    dataContext.Exams.Add(exam);
                    dataContext.SaveChanges();

                    List<int> l = new List<int>();
                    for (int i = 0; i < 10; i++)
                    {
                        int QId;
                        do
                        {
                            QId = random.Next(QIds.Min(), QIds.Max()+1);
                        } while (l.Contains(QId) | !QIds.Contains(QId));
                        l.Add(QId);
                        QuestionPool q = dataContext.QuestionPool.FirstOrDefault(c => c.Id == QId);
                        dataContext.Exams.Include("questionsId").FirstOrDefault(x => x.Id == exam.Id).questionsId.Add(q);
                        dataContext.SaveChanges();
                    }
                    textBox1.Text = exam.Id.ToString();

                    MessageBox.Show("Exam is assigened successfully");
                }
                else
                {
                    MessageBox.Show("Questiom pool must have more 10 questions");
                }
            }
            else
            {
                MessageBox.Show("Must determinate time of exam");
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value=(int)numericUpDown1.Value;
        }

        private void MakeExam_Load(object sender, EventArgs e)
        {
           //numericUpDown1.CanFocus = false;
        }
    }
}
