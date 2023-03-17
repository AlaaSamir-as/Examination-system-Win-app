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

namespace ExaminationSytem
{
    public partial class ChangePass : Form
    {
        DataContext dataContext=new DataContext();
        public ChangePass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!= "" && textBox2.Text!="" && textBox3.Text!="")
            {
                if (textBox1.Text == dataContext.Logins.Where(i => i.UserName == LoginForm.CurrentUserName).Select(i => i.Password).FirstOrDefault())
                {
                    if(textBox2.Text==textBox3.Text)
                    {
                        var pass=dataContext.Logins.Where(i => i.UserName == LoginForm.CurrentUserName).Select(i => i).FirstOrDefault();
                        pass.Password = textBox3.Text;
                        dataContext.SaveChanges();
                        MessageBox.Show("You change Password successfully");
                    }
                    else
                    {
                        MessageBox.Show("new password is not same \nplease write same new password to confirm");
                    }
                }
                else
                {
                    MessageBox.Show("Old password is incorrect");
                }
            }
            else
            {
                MessageBox.Show("Please complete all fields");
            }
        }
    }
}
