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
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm!=null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel= false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(childForm);
            mainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {

        }

        private void btnMngStudent_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageStudent());
        }

        private void btnMngInst_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageInstructor());
        }

        private void btnMngCourse_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageCourse());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm logg = new LoginForm();
            logg.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new ManagerSTA());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new ChangePass());

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
