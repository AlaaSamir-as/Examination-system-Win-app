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

namespace ExaminationSytem
{
    public partial class ManagerSTA : Form
    {
        DataContext context = new DataContext();
        public ManagerSTA()
        {
            InitializeComponent();
        }

        private void ManagerSTA_Load(object sender, EventArgs e)
        {
            Dictionary<string, int?> stscore = new Dictionary<string, int?>();

            var ins = context.Instructors.Select(i => i.Id).ToList();
            foreach (var item in ins)
            {
                var stname = context.Students.Where(s => s.InstructorId == item).Select(s => s.Id).ToList().Count;
                var coursename = context.Courses.Where(i => i.InstructorId==item).Select(i=>i.Name).FirstOrDefault();
                stscore.Add(coursename, stname);

            }
            foreach (var item in stscore)
            {
                chart1.Series["Course"].Points.AddXY(item.Key,item.Value);
            }

        }
    }
}
