using ExaminationSystem;
using ExaminationSytem.InstructorUC;
using Guna.UI2.WinForms.Suite;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormProject
{
    public partial class Assigant_student : Form
    {
        DataContext context = new DataContext();
        public string exid { get; set; }
        public Assigant_student()
        {
            InitializeComponent();
            //txb_ExamID.Text = exid;

        }
        DataTable dtable = new DataTable();
        private void Assigant_student_Load(object sender, EventArgs e)
        {
 
            var query = context.Students.Where(s=>s.Instructor.Username==LoginForm.CurrentUserName)
                .Select(s =>new { s.Id,s.FName, }).ToList();
            DGV_Students.DataSource = query;
            // DataTable dtable = new DataTable();
            
            dtable.Columns.Add("StudentID", typeof(int));
            dtable.PrimaryKey = new DataColumn[] { dtable.Columns["StudentID"] };

            dtable.Columns.Add("StudentName", typeof(string));

            var ExamIds = context.Exams.Select(i => i.Id).ToList();

            //Fill the DataTable with records from Table.
            //DataTable dt = new DataTable();
            ComboBoxExamIDs.DataSource = ExamIds;


            //Assign DataTable as DataSource.
            ComboBoxExamIDs.DisplayMember = "Id";
            //ComboBoxExamIDs.ValueMember = "Id";



        }




        private void btn_add_student_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow item in DGV_Students.Rows)
            {
                if (item.Selected)
                {
                    var x = item.Cells[0].Value;
                    var y = item.Cells[1].Value;
                    if (dtable.Rows.Contains(x))
                    {
                        MessageBox.Show($"This Student Id:{x} is Already Add", "Duplicate Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    else { dtable.Rows.Add(x, y); }

                }
            }
            DGV_Asigned_STudent.DataSource = dtable;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in DGV_Asigned_STudent.Rows)
            {
                if (item.Selected)
                {
                    DGV_Asigned_STudent.Rows.Remove(item);

                }
            }   
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            int examId=(int)ComboBoxExamIDs.SelectedItem;
            var examids=context.Exams.Select(x => x.Id).ToList();
            if (DGV_Asigned_STudent.Rows.Count > 0) 
            {

                ///////////code eng.aya
                List<QuestionPool> f = new List<QuestionPool>();
                var examssss = context.Exams.Include("questionsId").Where(i => i.Id == examId);
                foreach (var i in examssss)
                {
                    f = i.questionsId;
                };


                //var query= context.QuestionPool.Where(q=> examids.Contains(examId)).Select(q=>q.Id).ToList();
                var rows = DGV_Asigned_STudent.Rows;

                for(int i=0; i<rows.Count; i++)
                {
                    int stid= (int)DGV_Asigned_STudent.Rows[i].Cells[0].Value;
                    foreach (var item in f)
                    {
                        StExam stExam = new StExam() { ExId = examId, QId = item.Id, StId = stid };
                        context.StExams.Add(stExam);
                        try 
                        {
                            context.SaveChanges();

                        } catch 
                        {
                            MessageBox.Show("Student is added before");
                            return;
                        }
                    }
                }
                MessageBox.Show("Students are assigned successfully");
            }
            else
            {
                MessageBox.Show("PLease add student first");
            }
        }

        private void lblExamID_Click(object sender, EventArgs e)
        {

        }
    }
}
