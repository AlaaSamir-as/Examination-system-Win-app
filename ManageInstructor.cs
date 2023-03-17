using Guna.UI2.WinForms.Suite;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ExaminationSystem
{
    public partial class ManageInstructor : Form
    {
        public ManageInstructor()
        {
            InitializeComponent();
            dataGridViewInstructors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ManageInstructor_Load(object sender, EventArgs e)
        {
            DataContext data2 = new DataContext();
            dataGridViewInstructors.Columns.Add("id", "ID");
            dataGridViewInstructors.Columns.Add("fName", "Name");
            dataGridViewInstructors.Columns.Add("UserName", "User Name");
            dataGridViewInstructors.Columns.Add("pass", "Password");

            var instID = data2.Instructors;

            foreach (var item in instID)
            {
                var instLoginPass = data2.Logins.Where(i => item.Username == i.UserName).Select(i => i.Password).FirstOrDefault();
                dataGridViewInstructors.Rows.Add(item.Id.ToString(), item.FName.ToString(), item.Username.ToString(), instLoginPass.ToString());
            }

            dataGridViewInstructors.ClearSelection();
            txtInstName.Clear();
            txtInstUsername.Clear();
            txtInstPass.Clear();
        }

        //Adding Instructor 
        private void btnAddInst_Click(object sender, EventArgs e)
        {
            #region Validate Adding Instructor
            string InstUserName = "";
            string InstName = "";
            string InstPassword = "";
            string InstType = "Inst";
            int validation = 0;


            if (txtInstName.Text.Trim().Length > 0)
            {
                InstName = txtInstName.Text;
                validation++;
            }
            else MessageBox.Show("Name Can't be Empty");


            if (txtInstUsername.Text.Trim().Length > 0)
            {
                InstUserName = txtInstUsername.Text;
                DataContext data = new DataContext();
                var users = data.Logins.Select(i => i.UserName);
                int flage = 0;
                foreach (var item in users)
                {
                    if (item.ToUpper() == InstUserName.ToUpper())
                    {
                        flage++;
                    }

                }
                if (flage == 0)
                {

                    validation++;
                }
                else
                {
                    MessageBox.Show("This Username is already exist", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("UserName Can't be Empty");

            if (txtInstPass.Text.Trim().Length > 0)
            {
                InstPassword = txtInstPass.Text;
                validation++;
            }
            else MessageBox.Show("Password Can't be Empty");

            #endregion

            if (validation == 3)
            {
                DataContext dataContext = new DataContext();
                Login l1 = new Login()
                {
                    UserName = InstUserName,
                    Password = InstPassword,
                    Type = InstType
                };
                dataContext.Logins.Add(l1);
                dataContext.SaveChanges();


                Instructor ins1 = new Instructor()
                {
                    FName = InstName,
                    Username = l1.UserName,
                    ManagerId = 2,
                };

                dataContext.Instructors.Add(ins1);
                dataContext.SaveChanges();



                MessageBox.Show($"Instructor {ins1.FName} added Successfully");
                dataGridViewInstructors.Rows.Add(ins1.Id, ins1.FName, ins1.Username, l1.Password);
                txtInstName.Text = "";
                txtInstPass.Text = "";
                txtInstUsername.Text = "";


            }



        }

        //Validate textbox (instName) ==> make it not allow numbers
        string oldText = string.Empty;
        private void txtInstName_TextChanged(object sender, EventArgs e)
        {
            if (txtInstName.Text.All(chr => char.IsLetter(chr) || chr == ' '))
            {
                oldText = txtInstName.Text;
                txtInstName.Text = oldText;

                txtInstName.BackColor = System.Drawing.Color.White;
                txtInstName.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtInstName.Text = oldText;
                txtInstName.BackColor = System.Drawing.Color.Red;
                txtInstName.ForeColor = System.Drawing.Color.White;
            }
            txtInstName.SelectionStart = txtInstName.Text.Length;
        }

        //For Update Instructor
            
        private void dataGridViewInstructors_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewInstructors.CurrentRow != null)
            {
                lblID.Text = dataGridViewInstructors.CurrentRow.Cells[0].Value.ToString();
                lblUserName.Text = dataGridViewInstructors.CurrentRow.Cells[2].Value.ToString();

                txtInstName.Text = dataGridViewInstructors.CurrentRow.Cells[1].Value.ToString();
                txtInstUsername.Text = dataGridViewInstructors.CurrentRow.Cells[2].Value.ToString();
                txtInstPass.Text = dataGridViewInstructors.CurrentRow.Cells[3].Value.ToString();

            }


        }
        int indexRow;
        //private void dataGridViewInstructors_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    indexRow = e.RowIndex;
        //    DataGridViewRow row = dataGridViewInstructors.Rows[indexRow];
        //    ////
        //    lblID.Text = row.Cells[0].Value.ToString();
        //    lblUserName.Text = row.Cells[2].Value.ToString();
        //    ///
        //    txtInstName.Text = row.Cells[1].Value.ToString();
        //    txtInstUsername.Text = row.Cells[2].Value.ToString();
        //    txtInstPass.Text = row.Cells[3].Value.ToString();
       // }

        //Update Button
        private void btnUpdateInst_Click(object sender, EventArgs e)
        {
            #region Validate Adding Instructor
            string InstUserName = "";
            string InstName = "";
            string InstPassword = "";
            string InstType = "Inst";
            int validation = 0;


            if (txtInstName.Text.Trim().Length > 0)
            {
                InstName = txtInstName.Text;
                validation++;

            }
            else MessageBox.Show("Name Can't be Empty");


            if (txtInstUsername.Text.Trim().Length > 0)
            {
                InstUserName = txtInstUsername.Text;
                validation++;
            }
            else MessageBox.Show("UserName Can't be Empty");


            if (txtInstPass.Text.Trim().Length > 0)
            {
                InstPassword = txtInstPass.Text;
                validation++;
            }
            else MessageBox.Show("Password Can't be Empty");

            #endregion

            if (validation == 3)
            {
                DataContext dataContext = new DataContext();
                var logg = dataContext.Logins.Where(i => i.UserName == lblUserName.Text.ToString()).Select(i => i).FirstOrDefault();
                logg.UserName = InstUserName;
                logg.Password = InstPassword;
                logg.Type = InstType;


                    int idd = int.Parse(lblID.Text);
                    Instructor ins1 = dataContext.Instructors.Select(i => i).Where(i => i.Id == idd).FirstOrDefault();
                try
                {
                    dataContext.SaveChanges();
                    ins1.FName = InstName;
                    //ins1.Username = logg.UserName;
                    ins1.ManagerId = 2;

                    dataContext.SaveChanges();
                    MessageBox.Show($"Instructor {ins1.FName} updated Successfully");
                    DataGridViewRow newDataRow = dataGridViewInstructors.Rows[indexRow];
                    newDataRow.Cells[1].Value = txtInstName.Text;
                    newDataRow.Cells[2].Value = txtInstUsername.Text;
                    newDataRow.Cells[3].Value = txtInstPass.Text;
                }
                catch
                {
                    MessageBox.Show("UserName Cannot be changed");
                }








                txtInstName.Text = "";
                txtInstPass.Text = "";
                txtInstUsername.Text = "";


            }else MessageBox.Show("there is error");
            
            
        }

        private void btnDeleteInst_Click(object sender, EventArgs e)
        {
            DialogResult ms = MessageBox.Show("You are about to delete instructor \n Are you sure? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ms == DialogResult.Yes)
            {
                #region Validate Delete Instructor
                string InstUserName = "";



                if (txtInstUsername.Text.Length > 0)
                {
                    InstUserName = txtInstUsername.Text;
                    DataContext data = new DataContext();
                    var users = data.Logins.Select(i => i).Where(i => i.UserName == InstUserName).FirstOrDefault();
                    int idRemovedInst = int.Parse(lblID.Text.ToString());
                    var inst = data.Instructors.Select(i => i).Where(i => i.Id == idRemovedInst).FirstOrDefault();
                    if (users != null && inst != null)
                    {
                        var studentss = data.Students.Where(i => i.Instructor.Username == inst.Username).ToList();
                        var courses = data.Courses.Where(i => i.Instructor.Username == inst.Username).ToList();
                        var exams = data.Exams.Where(i => i.InstructorId.Username == inst.Username).ToList();

                        if (studentss.Count == 0 && courses.Count == 0 && exams.Count == 0)
                        {

                            data.Logins.Remove(users);
                            data.SaveChanges();
                            //data.Instructors.Remove(inst);
                            //data.SaveChanges();
                        }
                        else
                        {
                            foreach (var item in studentss)
                            {
                                item.InstructorId = null;
                                data.SaveChanges();
                            }
                            foreach (var x in courses)
                            {
                                x.InstructorId = null;
                                data.SaveChanges();
                            }
                            foreach (var item in exams)
                            {
                                item.InstructorId = null;
                                data.SaveChanges();
                            }
                            data.Logins.Remove(users);
                            data.SaveChanges();
                            //data.Instructors.Remove(inst);
                            //data.SaveChanges();
                        }


                        MessageBox.Show($"Instructor: {InstUserName} deleted Successfully");

                        //DataGridViewRow newDataRow = dataGridViewInstructors.Rows[indexRow];
                        //newDataRow.Cells[0].Value = "";
                        //newDataRow.Cells[1].Value = "";
                        //newDataRow.Cells[2].Value = "";
                        //newDataRow.Cells[3].Value = "";

                        dataGridViewInstructors.Rows.Clear();

                        var instID = data.Instructors;

                        foreach (var item in instID)
                        {
                            var instLoginPass = data.Logins.Where(i => item.Username == i.UserName).Select(i => i.Password).FirstOrDefault();
                            dataGridViewInstructors.Rows.Add(item.Id.ToString(), item.FName.ToString(), item.Username.ToString(), instLoginPass.ToString());
                        }

                        //DataContext data2 = new DataContext();
                        //var instID2 = data2.Instructors;
                        //foreach (var item in instID2)
                        //{
                        //    var instLoginPass = data2.Logins.Where(i => item.Username == i.UserName).Select(i => i.Password).FirstOrDefault();
                        //    dataGridViewInstructors.Rows.Add(item.Id.ToString(), item.FName.ToString(), item.Username.ToString(), instLoginPass.ToString());
                        //}
                    }
                    else MessageBox.Show("This Username isn't Found");


                }
                else MessageBox.Show("UserName Can't be Empty");
                #endregion
            }
        }

    }
}
