using ExaminationSytem;
using ExaminationSytem.InstructorUC;
using FormProject;
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
    public partial class InstructorForm : Form
    {
        DataContext dataContext = new DataContext();
        public InstructorForm()
        {
            InitializeComponent();
            panel2.Visible=false;
        }

        private void btn_AddQuestion_Click(object sender, EventArgs e)
        {
            panel2.Visible= true;
            Add_Questions add_Questions= new Add_Questions();
            panel2.Controls.Add(add_Questions);
            add_Questions.BringToFront();
        }

        private void btn_MakeExam_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            MakeExam makeExam = new MakeExam();
            panel2.Controls.Add(makeExam);
            makeExam.BringToFront();
        }

        private void btn_AssignStd_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            Assigant_student assigant_Student = new Assigant_student();
            assigant_Student.TopLevel = false;
            panel2.Controls.Add(assigant_Student);
            assigant_Student.Show();
            assigant_Student.BringToFront();
        }

        private void btn_ShowResult_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            Show_Result show_Result = new Show_Result();
            show_Result.TopLevel = false;
            panel2.Controls.Add(show_Result);
            show_Result.Show();
            show_Result.BringToFront();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm logg = new LoginForm();
            logg.ShowDialog();
            this.Close();
        }

        private void InstructorForm_Load(object sender, EventArgs e)
        {
            InstUserName.Text = LoginForm.CurrentUserName;
            var instName = dataContext.Instructors.Where(i => i.Username == LoginForm.CurrentUserName).FirstOrDefault();
            InstaName.Text = instName.FName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            STA sta = new STA();
            sta.TopLevel = false;
            panel2.Controls.Add(sta);
            sta.Show();
            sta.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            ChangePass sta = new ChangePass();
            sta.TopLevel = false;
            panel2.Controls.Add(sta);
            sta.Show();
            sta.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
