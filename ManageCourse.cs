using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExaminationSystem
{
    public partial class ManageCourse : Form
    {
        public ManageCourse()
        {
            InitializeComponent();
            dataGridViewCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ManageCourse_Load(object sender, EventArgs e)
        {

            DataContext data = new DataContext();
            dataGridViewCourses.Columns.Add("id", "ID");
            dataGridViewCourses.Columns.Add("Name", "Name");
            dataGridViewCourses.Columns.Add("MaxDegree", "Max Degree");
            dataGridViewCourses.Columns.Add("MinDegree", "Min Degree");
            dataGridViewCourses.Columns.Add("CourseInstructor", "Course Instructor");

            var CourseId = data.Courses;

            foreach (var item in CourseId)
            {
                if (item.InstructorId == null)
                {
                    dataGridViewCourses.Rows.Add(item.Id.ToString(), item.Name.ToString(), item.MaxDegree.ToString(), item.MinDegree.ToString(),"Unkown");

                }
                else
                {

                    var InstName = data.Instructors.Select(i => i).Where(i => i.Id == item.InstructorId).FirstOrDefault();
                    dataGridViewCourses.Rows.Add(item.Id.ToString(), item.Name.ToString(), item.MaxDegree.ToString(), item.MinDegree.ToString(), InstName.FName.ToString());
                }

                
            }


            //Fill Combo Box With Insructors
            var instructrs = data.Instructors.Select(i => new { i.Id , i.FName } ).ToList();

            //Fill the DataTable with records from Table.
            DataTable dt = new DataTable();
            ComboBoxInstructors.DataSource = instructrs;

           
            //Assign DataTable as DataSource.
            ComboBoxInstructors.DisplayMember = "FName";
            ComboBoxInstructors.ValueMember = "Id";

            dataGridViewCourses.ClearSelection();
            txtCourseName.Clear();
            ComboBoxInstructors.SelectedIndex = -1;
            crsMaxDeg.Value = 0;
            crsMinDeg.Value = 0;
            

        }

        //Button Add 
        private void btnAddStud_Click(object sender, EventArgs e)
        {
            #region Validate Adding Instructor
            string CourseName = "";
            string CourseInstId = "";
            int MaxDeg = 10 ;
            int MinDeg = 0 ;
            int validation = 0;


            DataContext data2 = new DataContext();
            if (txtCourseName.Text.Trim().Length > 0)
            {
                CourseName = txtCourseName.Text;
                var CourseNames = data2.Courses.Select(i => i.Name);
                int flage = 0;
                foreach (var item in CourseNames)
                {
                    if (item == CourseName)
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
                    MessageBox.Show("This Course is already exist", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else MessageBox.Show("Course Name Can't be Empty");

            CourseInstId = ComboBoxInstructors.SelectedValue.ToString();
            MaxDeg = int.Parse(crsMaxDeg.Value.ToString());
            MinDeg = int.Parse(crsMinDeg.Value.ToString());

            if (MaxDeg > MinDeg)
            {
                validation++;   
                if (validation == 2)
                {
                    Course course = new Course()
                    {
                        Name = CourseName,
                        MaxDegree = MaxDeg,
                        MinDegree = MinDeg,
                        InstructorId =int.Parse(CourseInstId)
                    };
                    data2.Courses.Add(course);
                    data2.SaveChanges();
                    var instId = int.Parse(CourseInstId);
                    var CourseInstName = data2.Instructors.Select(i => i).Where(i => i.Id == instId).FirstOrDefault();
                    MessageBox.Show($"Course {course.Name} added Successfully");
                    dataGridViewCourses.Rows.Add(course.Id,course.Name,course.MaxDegree,course.MinDegree,CourseInstName.FName);
                    txtCourseName.Text = "";
                }
                else MessageBox.Show("There is an Error!! Please Try again");
            }
            else MessageBox.Show("Max Degree must be greater than Min Degree");

            #endregion


        }


        //Update Course Data
        int indexRow;
        private void dataGridViewCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //indexRow = e.RowIndex;
            //DataGridViewRow row = dataGridViewCourses.Rows[indexRow];
            //////
            //lblID.Text = row.Cells[0].Value.ToString();
            /////
            //txtCourseName.Text = row.Cells[1].Value.ToString();
            //crsMaxDeg.Text = row.Cells[2].Value.ToString();
            //crsMinDeg.Text = row.Cells[3].Value.ToString();
            //ComboBoxInstructors.SelectedItem = row.Cells[4].Value.ToString();
        }



        //Button Update
        private void btnUpdateStud_Click(object sender, EventArgs e)
        {
            #region Validate Updating Course
            string CourseName = "";
            string CourseInstId = "";
            int MaxDeg = 10;
            int MinDeg = 0;
            int validation = 0;

            DataContext data2 = new DataContext();
            if (txtCourseName.Text.Trim().Length > 0)
            {
                CourseName = txtCourseName.Text;
                var CourseNames = data2.Courses.Select(i => i.Name);
                int flage = 0;
                foreach (var item in CourseNames)
                {
                    if (item == CourseName)
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
                    MessageBox.Show("This Course is already exist", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else MessageBox.Show("Course Name Can't be Empty");

            CourseInstId = ComboBoxInstructors.SelectedValue.ToString();
            MaxDeg = int.Parse(crsMaxDeg.Value.ToString());
            MinDeg = int.Parse(crsMinDeg.Value.ToString());
            if (MaxDeg > MinDeg)
            {
                validation++;

                #endregion

                if (validation == 2)
                {
                    DataContext dataContext = new DataContext();
                    int idd = int.Parse(lblID.Text);
                    var course = dataContext.Courses.Where(i => i.Id == idd).Select(i => i).FirstOrDefault();
                    course.Name = CourseName;
                    course.MaxDegree = MaxDeg;
                    course.MinDegree = MinDeg;
                    course.InstructorId = int.Parse(CourseInstId);

                    dataContext.SaveChanges();

                    var instId = int.Parse(CourseInstId);
                    var CourseInstName = data2.Instructors.Select(i => i).Where(i => i.Id == instId).FirstOrDefault();
                    MessageBox.Show($"course {course.Name} updated Successfully");
                    //DataGridViewRow newDataRow = dataGridViewCourses.Rows[indexRow];
                    //newDataRow.Cells[1].Value = txtCourseName.Text;
                    //newDataRow.Cells[2].Value = crsMaxDeg.Text;
                    //newDataRow.Cells[3].Value = crsMinDeg.Text;
                    //newDataRow.Cells[4].Value = CourseInstName.FName;

                    dataGridViewCourses.CurrentRow.Cells[1].Value = txtCourseName.Text;
                    dataGridViewCourses.CurrentRow.Cells[2].Value = crsMaxDeg.Text;
                    dataGridViewCourses.CurrentRow.Cells[3].Value = crsMinDeg.Text;
                    dataGridViewCourses.CurrentRow.Cells[4].Value = CourseInstName.FName;

                    txtCourseName.Text = "";
                    crsMaxDeg.Value = 0;
                    crsMinDeg.Value = 0;
                    ComboBoxInstructors.SelectedIndex = 0;

                }
                else MessageBox.Show("there is error");
            }
            else MessageBox.Show("Max Degree must be greater than Min Degree");
        }
       

        //Button Delete
        private void btnDeleteStud_Click(object sender, EventArgs e)
        {
            DialogResult ms = MessageBox.Show("You are about to delete course data \n Are you sure? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ms == DialogResult.Yes)
            {
                #region Validate Delete Instructor
                int CourseId;

                CourseId = int.Parse(lblID.Text.ToString());
                DataContext data = new DataContext();
                var course = data.Courses.Select(i => i).Where(i => i.Id == CourseId).FirstOrDefault();




                data.Courses.Remove(course);
                data.SaveChanges();
                MessageBox.Show($"Course: {course.Name} deleted Successfully");

                //DataGridViewRow newDataRow = dataGridViewCourses.Rows[indexRow];
                //newDataRow.Cells[0].Value = "";
                //newDataRow.Cells[1].Value = "";
                //newDataRow.Cells[2].Value = "";
                //newDataRow.Cells[3].Value = "";
                //newDataRow.Cells[4].Value = "";
                var CourseIdd = data.Courses;

                dataGridViewCourses.Rows.Clear();
                foreach (var item in CourseIdd)
                {
                    if (item.InstructorId == null)
                    {

                        dataGridViewCourses.Rows.Add(item.Id.ToString(), item.Name.ToString(), item.MaxDegree.ToString(), item.MinDegree.ToString(), "Unkown");

                    }
                    else
                    {

                        var InstName = data.Instructors.Select(i => i).Where(i => i.Id == item.InstructorId).FirstOrDefault();
                        dataGridViewCourses.Rows.Add(item.Id.ToString(), item.Name.ToString(), item.MaxDegree.ToString(), item.MinDegree.ToString(), InstName.FName.ToString());
                    }


                }



                #endregion
            }
        }

        private void dataGridViewCourses_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridViewCourses.CurrentRow != null)
            {
                txtCourseName.Text = dataGridViewCourses.CurrentRow.Cells[1].Value.ToString();
                crsMaxDeg.Text = dataGridViewCourses.CurrentRow.Cells[2].Value.ToString();
                crsMinDeg.Text = dataGridViewCourses.CurrentRow.Cells[3].Value.ToString();
                ComboBoxInstructors.Text = dataGridViewCourses.CurrentRow.Cells[4].Value.ToString();

                lblID.Text = dataGridViewCourses.CurrentRow.Cells[0].Value.ToString();

                //txtStudUsername.Enabled=false;
            }
        }
    }
}
