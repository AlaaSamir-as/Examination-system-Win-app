using ExaminationSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormProject
{
    public partial class Show_Result : Form
    {
            DataTable dataTable= new DataTable();
        public Show_Result()
        {
            InitializeComponent();
        }

        private void Show_Result_Load(object sender, EventArgs e)
        {
            DataContext context=new DataContext();
            var query = context.StExams.Select(s=>s.StId).Distinct();
            var query2 = context.StExams.Select(s=>s.ExId).Distinct();
            //foreach (var item in query2)
            //{
            //    var students = context.Students.Where(i => i.Id == item.StId);
            //}



            dataTable.Columns.Add("StudentName", typeof(string));
            dataTable.Columns.Add("ExamID", typeof(int));
            dataTable.Columns.Add("StScore", typeof(int));

            foreach (var item in query)
            {
                var stname = context.Students.Where(s => s.Id == item).Select(s => s.FName).FirstOrDefault();
                foreach (var item2 in query2)
                {
                    var stexam = context.StExams.Where(s => s.StId == item).Where(s => s.ExId == item2).Select(s=>s.StScore);
                    var result = stexam.Sum();

                dataTable.Rows.Add(stname, item2, result);
                }

            }
            //var stname= context.
            DGV_ShowResult.DataSource= dataTable;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
