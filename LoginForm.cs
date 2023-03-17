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

namespace ExaminationSystem
{
    public partial class LoginForm : Form
    {
        DataContext dataContext = new DataContext();
        public static string CurrentUserName;
        public LoginForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var userName = txtUsername.Text;
            var pass = txtPassword.Text;

            if (RbtnAdmin.Checked)
            {
                var managerss = dataContext.Logins.Where(x => x.Type == "manager").ToList();
                foreach (var item in managerss)
                {
                    if (userName == item.UserName && pass == item.Password)
                    {
                        CurrentUserName = userName;
                        this.Hide();
                        ManagerForm managerForm = new ManagerForm();
                        managerForm.ShowDialog();
                        this.Close();
                        break;
                    }
                }
                MessageBox.Show("Username or Password are not correct  ");

            }
            else if (RbtnInstructor.Checked)
            {
                var instructorrs = dataContext.Logins.Where(x => x.Type == "inst").ToList();
                foreach (var item in instructorrs)
                {
                    if (userName == item.UserName && pass == item.Password)
                    {
                        CurrentUserName = txtUsername.Text;
                        this.Hide();
                        InstructorForm instructorForm = new InstructorForm();
                        instructorForm.ShowDialog();
                        this.Close();
                        break;
                    }
                }
                MessageBox.Show("Username or Password are not correct  ");


            }
            else if (RbtnStudent.Checked)
            {
                var Studentts = dataContext.Logins.Where(x => x.Type == "Student").ToList();
                foreach (var item in Studentts)
                {
                    if (userName == item.UserName && pass == item.Password)
                    {
                        CurrentUserName = txtUsername.Text;
                        this.Hide();
                        startTime startTime = new startTime();
                        startTime.ShowDialog();
                        this.Close();
                        break;
                    }
                }
                MessageBox.Show("Username or Password are not correct  ");


            }
            else
            {
                MessageBox.Show("You should choose usertype");
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
