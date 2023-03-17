using ExaminationSystem;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExaminationSytem.InstructorUC
{
    public partial class Add_Questions : UserControl
    {
        DataContext dataContext = new DataContext();
        public int courseid;
        public Add_Questions()
        {
            InitializeComponent();
             courseid = dataContext.Courses.Where(c => c.Instructor.Username == LoginForm.CurrentUserName).Select(i=>i.Id).FirstOrDefault();
            dataGridView1.DataSource = dataContext.QuestionPool.Where(i=>i.CourseId==courseid).ToList();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ClearSelection();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            DataContext dataContext = new DataContext();
            var q=dataContext.QuestionPool.Where(i=>i.CourseId==courseid).Select(i=>i).ToList();

            if (textBox1.Text.Trim() != "" && textBox6.Text.Trim() != "" && textBox3.Text.Trim() != ""
                && textBox2.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "")
            {
                bool flag = true;
                foreach (var item in q)
                {
                    if (textBox1.Text == item.Question) { flag = false; }
                }
                if (flag == true)
                {
                    if (textBox6.Text == textBox2.Text | textBox6.Text == textBox3.Text | textBox6.Text == textBox5.Text |
                        textBox6.Text == textBox4.Text)
                    {

                        QuestionPool questionPool = new QuestionPool()
                        {
                            Question = textBox1.Text,
                            Choice1 = textBox2.Text,
                            Choice2 = textBox3.Text,
                            Choice3 = textBox4.Text,
                            Choice4 = textBox5.Text,
                            CorrectAns = textBox6.Text,
                            //CourseId=dataContext.Instructors.Where(i=>i.Username==LoginForm.CurrentUserName).Select(i=>i.courses).Select(i=>i.);
                            CourseId = (from c in dataContext.Courses
                                        where c.Instructor.Username == LoginForm.CurrentUserName
                                        select c.Id).FirstOrDefault(),

                        };
                        dataContext.QuestionPool.Add(questionPool);
                        dataContext.SaveChanges();
                        int courseid = dataContext.Courses.Where(c => c.Instructor.Username == LoginForm.CurrentUserName).Select(i => i.Id).FirstOrDefault();
                        dataGridView1.DataSource = dataContext.QuestionPool.Where(i => i.CourseId == courseid).ToList();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();

                        MessageBox.Show("Question is added successfully");

                    }
                    else
                    {
                        MessageBox.Show("Correct Answer must be one of choices");
                    }
                }
                else
                {
                    MessageBox.Show(" question Can not be repeated ");
                }
            }
            else
            {
                MessageBox.Show("Complete data");

            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
        }

        private void btn_SaveQ_Click(object sender, EventArgs e)
        {
            var q = dataContext.QuestionPool.Where(i => i.CourseId == courseid).Select(i => i).ToList();

            if (textBox1.Text.Trim() != "" && textBox6.Text.Trim() != "" && textBox3.Text.Trim() != ""
                            && textBox2.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "")
            {
                int flag = 0;
                foreach (var item in q)
                {
                    if (textBox1.Text == item.Question) { flag ++; }
                }
                if (flag <= 1)
                {
                      if (textBox6.Text == textBox2.Text | textBox6.Text == textBox3.Text | textBox6.Text == textBox5.Text |
                        textBox6.Text == textBox4.Text)
                    {
                        dataGridView1.CurrentRow.Cells[1].Value = textBox1.Text;
                        dataGridView1.CurrentRow.Cells[2].Value = textBox2.Text;
                        dataGridView1.CurrentRow.Cells[3].Value = textBox3.Text;
                        dataGridView1.CurrentRow.Cells[4].Value = textBox4.Text;
                        dataGridView1.CurrentRow.Cells[5].Value = textBox5.Text;
                        dataGridView1.CurrentRow.Cells[6].Value = textBox6.Text;
                        //DataContext dataContext= new DataContext();
                        int index = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);


                        var question = dataContext.QuestionPool.Where(i => i.Id == index).Select(i=>i).FirstOrDefault();
                        question.Question = textBox1.Text;
                        question.Choice1 = textBox2.Text;
                        question.Choice2 = textBox3.Text;
                        question.Choice3 = textBox4.Text;
                        question.Choice4 = textBox5.Text;
                        question.CorrectAns= textBox6.Text;

                        dataContext.SaveChanges();
                        MessageBox.Show("Question is updated successfully");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Correct Answer must be one of choices");
                    }
                }
                else
                {
                    MessageBox.Show(" question Can not be repeated ");
                }
            }
            else
            {
                MessageBox.Show("Complete data");

            }
        }

        private void btn_ResetQ_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void btn_DeleteQ_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            QuestionPool q=dataContext.QuestionPool.Where(i => i.Id == x ).FirstOrDefault();
            dataContext.QuestionPool.Remove(q);
            dataContext.SaveChanges();
            //dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
            int courseid = dataContext.Courses.Where(c => c.Instructor.Username == LoginForm.CurrentUserName).Select(i => i.Id).FirstOrDefault();
            dataGridView1.DataSource = dataContext.QuestionPool.Where(i => i.CourseId == courseid).ToList();
            MessageBox.Show("Question is deleted successfully");
        }

        private void Add_Questions_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
    }
}
