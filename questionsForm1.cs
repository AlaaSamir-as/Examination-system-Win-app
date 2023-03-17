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
    public partial class questionsForm1 : Form
    {
        public static List<string> stans=new List<string>();
        public static List<int> qids=new List<int>();

        DataContext DataContext=new DataContext();
        public questionsForm1()
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            questionForm2 questionform2 = new questionForm2();

            questionform2.ShowDialog();
            this.Close();
        }

        private void questionsForm1_Load(object sender, EventArgs e)
        {
            //var qAll = DataContext.StExams.Where(i => i.ExId == startTime.examid).Select(i => i.QId).ToList();
            var qAll = DataContext.StExams.Where(i => i.ExId == startTime.examid).Where(i=>i.StId==startTime.stid).Select(i=>i.QId).ToList();
            //var q1ID=qAll.Select(i=>i==1);

            List<QuestionPool> list = new List<QuestionPool>();
            foreach (var item in qAll)
            {
                var qtext = (DataContext.QuestionPool.Where(i => i.Id == item).Select(i => i)).FirstOrDefault();
                list.Add(qtext);
            }
            q1.Text = list[0].Question;
            q1ans1.Text = list[0].Choice1;
            q1ans2.Text = list[0].Choice2;
            q1ans3.Text = list[0].Choice3;
            q1ans4.Text = list[0].Choice4;

            q2.Text = list[1].Question;
            q2ans1.Text = list[1].Choice1;
            q2ans2.Text = list[1].Choice2;
            q2ans3.Text = list[1].Choice3;
            q2ans4.Text = list[1].Choice4;

            q3.Text = list[2].Question;
            q3ans1.Text = list[2].Choice1;
            q3ans2.Text = list[2].Choice2;
            q3ans3.Text = list[2].Choice3;
            q3ans4.Text = list[2].Choice4;

            q4.Text = list[3].Question;
            q4ans1.Text = list[3].Choice1;
            q4ans2.Text = list[3].Choice2;
            q4ans3.Text = list[3].Choice3;
            q4ans4.Text = list[3].Choice4;

            q5.Text = list[4].Question;
            q5ans1.Text = list[4].Choice1;
            q5ans2.Text = list[4].Choice2;
            q5ans3.Text = list[4].Choice3;
            q5ans4.Text = list[4].Choice4;

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
                            //tbb.AutoCheck= false;
                        }
                    }
                }

            }
        }
        
        public List<string> Score1()
        {
                foreach (Control gb in panel1.Controls)
                {
                if (gb is GroupBox)
                {
                    foreach (Control tb in gb.Controls)
                        {
                            if (tb is RadioButton)
                            {
                                var tbb=(RadioButton)tb;

                                if(tbb.Checked==true)
                                {
                                    stans.Add(tbb.Text);
                                    int id=DataContext.QuestionPool.Where(q=>q.Question== gb.Text).Select(q=>q.Id).FirstOrDefault();
                                    qids.Add(id);
                                }
                            }
                        }
                }
            }
            return stans; 
        }

    }
}
