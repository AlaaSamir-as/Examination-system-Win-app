using ExaminationSytem;
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
    public partial class startTime : Form
    {
        DataContext dataContext=new DataContext();
        public static int examid { get; set; }
        public static int stid { get; set; }
        public startTime()
        {
            InitializeComponent();
            stid = dataContext.Students.Where(i => i.Username == LoginForm.CurrentUserName).Select(i=>i.Id).FirstOrDefault();
            var x = dataContext.StExams.Where(i => i.StId == stid).Select(i => i.ExId).Distinct().ToList();

            //Fill the DataTable with records from Table.
            comboBox1.DataSource = x;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            stid = dataContext.Students.Where(i => i.Username == LoginForm.CurrentUserName).Select(i => i.Id).FirstOrDefault();
            examid=(int)comboBox1.SelectedItem;
            var stAnswer=dataContext.StExams.Where(i=>i.ExId==examid).Where(i=>i.StId==stid).Select(i=>i.StAnswer).ToList();

            bool flag = true;
            foreach (var item in stAnswer)
            {
                if (item != null)
                {
                    flag = false;
                }
            }

            if (flag == true)
            {
                var stAnswer1 = dataContext.StExams.Where(i => i.ExId == examid).Where(i => i.StId == stid).Select(i => i).ToList();

                foreach (var item1 in stAnswer1)
                {
                    item1.StAnswer = string.Empty;
                    dataContext.SaveChanges();
                }
                this.Hide();
                ExamForm examForm = new ExamForm();
                examForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Can not take exam again");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void startTime_Load(object sender, EventArgs e)
        {
            examid=(int)comboBox1.SelectedItem;
            var examtime=dataContext.Exams.Where(i => i.Id==examid).Select(i=>i.TotalTime).FirstOrDefault();
            label4.Text = $"Exam time : {examtime} Min";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm logg = new LoginForm();
            logg.ShowDialog();
            this.Close();
        }
    }
}
