using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExaminationSystem
{
    public partial class questionForm2 : Form
    {
        public static List<string> stans = new List<string>();
        public static List<int> qids = new List<int>();
        DataContext DataContext=new DataContext();
        public questionForm2()
        {
            InitializeComponent();

            foreach (Control gb in panel1.Controls)
            {
                if (gb is GroupBox)
                {
                    foreach (Control tb in gb.Controls)
                    {
                        if (tb is RadioButton)
                        {
                            var tbb = (RadioButton)tb;
                            tbb.Checked = false;
                        }
                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            questionsForm1 questionform1 = new questionsForm1();

            questionform1.ShowDialog();
            this.Close();
        }

        private void questionForm2_Load(object sender, EventArgs e)
        {
            var qAll = DataContext.StExams.Where(i => i.ExId == startTime.examid).Select(i => i.QId);
            //var q1ID = qAll.Select(i => i == 1);

            List<QuestionPool> list = new List<QuestionPool>();
            foreach (var item in qAll)
            {
                var qtext = (DataContext.QuestionPool.Where(i => i.Id == item).Select(i => i)).FirstOrDefault();
                list.Add(qtext);
            }
            q6.Text = list[5].Question;
            q6ans1.Text = list[5].Choice1;
            q6ans2.Text = list[5].Choice2;
            q6ans3.Text = list[5].Choice3;
            q6ans4.Text = list[5].Choice4;

            q7.Text = list[6].Question;
            q7ans1.Text = list[6].Choice1;
            q7ans2.Text = list[6].Choice2;
            q7ans3.Text = list[6].Choice3;
            q7ans4.Text = list[6].Choice4;

            q8.Text = list[7].Question;
            q8ans1.Text = list[7].Choice1;
            q8ans2.Text = list[7].Choice2;
            q8ans3.Text = list[7].Choice3;
            q8ans4.Text = list[7].Choice4;

            q9.Text = list[8].Question;
            q9ans1.Text = list[8].Choice1;
            q9ans2.Text = list[8].Choice2;
            q9ans3.Text = list[8].Choice3;
            q9ans4.Text = list[8].Choice4;

            q10.Text = list[9].Question;
            q10ans1.Text = list[9].Choice1;
            q10ans2.Text = list[9].Choice2;
            q10ans3.Text = list[9].Choice3;
            q10ans4.Text = list[9].Choice4;


            foreach (Control gb in panel1.Controls)
            {
                if (gb is GroupBox)
                {
                    foreach (Control tb in gb.Controls)
                    {
                        if (tb is RadioButton)
                        {
                            var tbb = (RadioButton)tb;

                            tbb.Checked = false;
                            //tbb.AutoCheck = false;
                        }
                    }
                }

            }
        }

        public List<string> Score2()
        {
            foreach (Control gb in panel1.Controls)
            {
                if (gb is GroupBox)
                {
                    foreach (Control tb in gb.Controls)
                    {
                        if (tb is RadioButton)
                        {
                            var tbb = (RadioButton)tb;

                            if (tbb.Checked == true)
                            {
                                stans.Add(tbb.Text);
                                int id = DataContext.QuestionPool.Where(q => q.Question == gb.Text).Select(q => q.Id).FirstOrDefault();
                                qids.Add(id);
                                //sum++;
                            }
                        }
                    }
                }
            }
            return stans;
        }

        
    }
}
