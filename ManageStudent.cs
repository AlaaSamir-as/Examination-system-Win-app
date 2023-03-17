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
    public partial class ManageStudent : Form
    {
        public ManageStudent()
        {
            InitializeComponent();
            dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ManageStudent_Load(object sender, EventArgs e)
        {
            DataContext data = new DataContext();

            dataGridViewStudents.Columns.Add("id", "ID");
            dataGridViewStudents.Columns.Add("fName", "Name");
            dataGridViewStudents.Columns.Add("UserName", "User Name");
            dataGridViewStudents.Columns.Add("pass", "Password");
            dataGridViewStudents.Columns.Add("InstName", "Instructor");


            var students = data.Students.ToList();

            foreach (var item in students)
            {
                var studLoginPass = data.Logins.Where(i => item.Username == i.UserName).Select(i => i.Password).FirstOrDefault();
                if (item.InstructorId == null)
                {
                    dataGridViewStudents.Rows.Add(item.Id.ToString(), item.FName.ToString(), item.Username.ToString(), studLoginPass.ToString(), "Unkwon");

                }
                else
                {

                var studInstructor = data.Instructors.Where(i => item.InstructorId == i.Id).Select(i => i.FName).FirstOrDefault();
                dataGridViewStudents.Rows.Add(item.Id.ToString(), item.FName.ToString(), item.Username.ToString(), studLoginPass.ToString(),studInstructor.ToString());
                }
            }

            //Fill Combo Box With Insructors
            var instructrs = data.Instructors.Select(i => new { i.Id, i.FName }).ToList();

            //Fill the DataTable with records from Table.
            DataTable dt = new DataTable();
            ComboBoxInstructors.DataSource = instructrs;


            //Assign DataTable as DataSource.
            ComboBoxInstructors.DisplayMember = "FName";
            ComboBoxInstructors.ValueMember = "Id";

            dataGridViewStudents.ClearSelection();
            txtStudName.Clear();
            txtStudUsername.Clear();
            txtStudPass.Clear();
            ComboBoxInstructors.SelectedIndex = -1;
        }


        //Adding Students 
        private void btnAddStud_Click(object sender, EventArgs e)
        {
            #region Validate Adding Instructor
            string StudentUserName = "";
            string StudentName = "";
            string StudentPassword = "";
            string StudentInstId = "";
            string StudentType = "Student";
            int validation = 0;


            if (txtStudName.Text.Trim().Length > 0)
            {
                StudentName = txtStudName.Text;
                validation++;
            }
            else MessageBox.Show("Name Can't be Empty");


            if (txtStudUsername.Text.Trim().Length > 0)
            {
                StudentUserName = txtStudUsername.Text;
                DataContext data = new DataContext();
                var users = data.Logins.Select(i => i.UserName);
                int flage = 0;
                foreach (var item in users)
                {
                    if (item.ToUpper() == StudentUserName.ToUpper())
                    {
                        flage++;
                    }

                }
                if (flage == 0 )
                {

                    validation++;
                }
                else
                {
                    MessageBox.Show("This Username is already exist", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("UserName Can't be Empty");

            if (txtStudPass.Text.Trim().Length > 0)
            {
                StudentPassword = txtStudPass.Text;
                validation++;
            }
            else MessageBox.Show("Password Can't be Empty");

            #endregion
 
                StudentInstId = ComboBoxInstructors.SelectedValue.ToString();
  

            if (validation == 3)
            {
                DataContext dataContext = new DataContext();
                Login l1 = new Login()
                {
                    UserName = StudentUserName,
                    Password = StudentPassword,
                    Type = StudentType
                };
                dataContext.Logins.Add(l1);
                dataContext.SaveChanges();


                Student student = new Student()
                {
                    FName = StudentName,
                    Username = l1.UserName,
                    ManagerId =  2 ,
                    InstructorId = int.Parse(StudentInstId),

                };

                dataContext.Students.Add(student);
                dataContext.SaveChanges();



                MessageBox.Show($"Student {student.FName} added Successfully");
                var instructorr = dataContext.Instructors.Where(i => i.Id == student.InstructorId).Select(i => i.FName).FirstOrDefault();
                dataGridViewStudents.Rows.Add(student.Id, student.FName, student.Username, l1.Password, instructorr);
                txtStudName.Text = "";
                txtStudUsername.Text = "";
                txtStudPass.Text = "";


            }
            else MessageBox.Show("There is an Error!! Please Try again");

        }


        //Validate textbox (instName) ==> make it not allow numbers
        string oldText = string.Empty;
        private void txtStudName_TextChanged(object sender, EventArgs e)
        {
            if (txtStudName.Text.All(chr => char.IsLetter(chr) || chr == ' '))
            {
                oldText = txtStudName.Text;
                txtStudName.Text = oldText;

                txtStudName.BackColor = System.Drawing.Color.White;
                txtStudName.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                txtStudName.Text = oldText;
                txtStudName.BackColor = System.Drawing.Color.Red;
                txtStudName.ForeColor = System.Drawing.Color.White;
            }
            txtStudName.SelectionStart = txtStudName.Text.Length;
        }

        //Updating Students

        int indexRow;
        private void dataGridViewStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //indexRow = e.RowIndex;
            //DataGridViewRow row = dataGridViewStudents.Rows[indexRow];
            ////
            //lblID.Text = row.Cells[0].Value.ToString();
            //lblUserName.Text = row.Cells[2].Value.ToString();
            /////
            //txtStudName.Text = row.Cells[1].Value.ToString();
            //txtStudUsername.Text = row.Cells[2].Value.ToString();
            //txtStudPass.Text = row.Cells[3].Value.ToString();
            //ComboBoxInstructors.SelectedItem = row.Cells[4].Value.ToString();
        }

        private void btnUpdateStud_Click(object sender, EventArgs e)
        {

            #region Validate Adding Instructor
            string StudentName = "";
            string studUserName = "";
            string StudPassword = "";
            string StudType = "Student";
            int validation = 0;


            if (txtStudName.Text.Trim().Length > 0)
            {
                StudentName = txtStudName.Text;
                validation++;

            }
            else MessageBox.Show("Name Can't be Empty");

            DataContext data2 = new DataContext();
            if (txtStudUsername.Text.Trim().Length > 0)
            {
                studUserName = txtStudUsername.Text;
                var StudentNames = data2.Students.Select(i => i.Username);
                int flage = 0;
                foreach (var item in StudentNames)
                {
                    if (item == studUserName)
                    {
                        flage++;
                    }

                }
                if (flage == 0 || flage == 1)
                {

                    validation++;
                }
                else
                {
                    MessageBox.Show("This Student is already exist", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                
            }
            else MessageBox.Show("UserName Can't be Empty");


            if (txtStudPass.Text.Trim().Length > 0)
            {
                StudPassword = txtStudPass.Text;
                validation++;
            }
            else MessageBox.Show("Password Can't be Empty");

            #endregion
            var StudentIstaID = ComboBoxInstructors.SelectedValue.ToString();
            if (validation == 3)
            {
                DataContext dataContext = new DataContext();
                var logg = dataContext.Logins.Where(i => i.UserName == lblUserName.Text.ToString()).Select(i => i).FirstOrDefault();
                logg.UserName = studUserName;
                logg.Password = StudPassword;
                logg.Type = StudType;
                try
                {
                dataContext.SaveChanges();
                int idd = int.Parse(lblID.Text);
                Student ins1 = dataContext.Students.Select(i => i).Where(i => i.Id == idd).FirstOrDefault();
                ins1.FName = StudentName;
               // ins1.Username = logg.UserName;
                ins1.ManagerId = 2;
                ins1.InstructorId = int.Parse(StudentIstaID);
                dataContext.SaveChanges();

                var instId = int.Parse(StudentIstaID);
                var StudentINstName = data2.Instructors.Select(i => i).Where(i => i.Id == instId).FirstOrDefault();
                //DataGridViewRow newDataRow = dataGridViewStudents.Rows[indexRow];

                dataGridViewStudents.CurrentRow.Cells[1].Value = txtStudName.Text;
                dataGridViewStudents.CurrentRow.Cells[2].Value = txtStudUsername.Text;
                dataGridViewStudents.CurrentRow.Cells[3].Value = txtStudPass.Text;
                dataGridViewStudents.CurrentRow.Cells[4].Value = StudentINstName.FName;


                MessageBox.Show($"Student {ins1.FName} updated Successfully");
                }
                catch 
                {
                    MessageBox.Show("UserName Cannot be changed");
                }




                //newDataRow.Cells[1].Value = txtStudName.Text;
                //newDataRow.Cells[2].Value = txtStudUsername.Text;
                //newDataRow.Cells[3].Value = txtStudPass.Text;
                //newDataRow.Cells[4].Value = StudentINstName.FName;

                txtStudName.Text = "";
                txtStudPass.Text = "";
                txtStudUsername.Text = "";

                //txtStudUsername.Enabled = true;
            }
            else MessageBox.Show("there is error");


        }

        private void btnDeleteStud_Click(object sender, EventArgs e)
        {
           DialogResult ms= MessageBox.Show("You are about to delete student data including his scores \n Are you sure? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ms==DialogResult.Yes)
            {
            #region Validate Delete Student
            string StudentUserName = "";



            if (txtStudUsername.Text.Length > 0)
            {
                StudentUserName = txtStudUsername.Text;
                DataContext data = new DataContext();
                var users = data.Logins.Select(i => i).Where(i => i.UserName == StudentUserName).FirstOrDefault();
                int idRemovedStudent = int.Parse(lblID.Text.ToString());
                var Studentt = data.Students.Select(i => i).Where(i => i.Id == idRemovedStudent).FirstOrDefault();
                if (users != null && Studentt != null)
                {
                    data.Logins.Remove(users);
                    data.Students.Remove(Studentt);
                    data.SaveChanges();
                    MessageBox.Show($"Student: {StudentUserName} deleted Successfully");

                    //DataGridViewRow newDataRow = dataGridViewStudents.Rows[indexRow];
                    //newDataRow.Cells[0].Value = "";
                    //newDataRow.Cells[1].Value = "";
                    //newDataRow.Cells[2].Value = "";
                    //newDataRow.Cells[3].Value = "";
                    //newDataRow.Cells[4].Value = "";

                    dataGridViewStudents.Rows.Clear();


                    var students = data.Students.ToList();

                    foreach (var item in students)
                    {
                        var studLoginPass = data.Logins.Where(i => item.Username == i.UserName).Select(i => i.Password).FirstOrDefault();
                        if (item.InstructorId == null)
                        {
                            dataGridViewStudents.Rows.Add(item.Id.ToString(), item.FName.ToString(), item.Username.ToString(), studLoginPass.ToString(), "Unkwon");

                        }
                        else
                        {

                            var studInstructor = data.Instructors.Where(i => item.InstructorId == i.Id).Select(i => i.FName).FirstOrDefault();
                            dataGridViewStudents.Rows.Add(item.Id.ToString(), item.FName.ToString(), item.Username.ToString(), studLoginPass.ToString(), studInstructor.ToString());
                        }
                    }



                }
                else MessageBox.Show("This Username isn't Found");


            }
            else MessageBox.Show("UserName Can't be Empty");
            #endregion
                
            }

        }

        private void dataGridViewStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewStudents.CurrentRow != null)
            {
                txtStudName.Text = dataGridViewStudents.CurrentRow.Cells[1].Value.ToString();
                txtStudUsername.Text = dataGridViewStudents.CurrentRow.Cells[2].Value.ToString();
                txtStudPass.Text = dataGridViewStudents.CurrentRow.Cells[3].Value.ToString();
                ComboBoxInstructors.Text = dataGridViewStudents.CurrentRow.Cells[4].Value.ToString();

                lblID.Text = dataGridViewStudents.CurrentRow.Cells[0].Value.ToString();
                lblUserName.Text = dataGridViewStudents.CurrentRow.Cells[2].Value.ToString();

                //txtStudUsername.Enabled=false;
            }
        }
    }
}
