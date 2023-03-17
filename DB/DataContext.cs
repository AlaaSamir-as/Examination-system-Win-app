using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace ExaminationSystem
{
    internal class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection") { }
        //Data Source = DELL - PC; Initial Catalog = Company; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
        public DbSet<Student> Students { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<QuestionPool> QuestionPool { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StExam> StExams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StExam>().HasKey(x => new { x.StId, x.ExId,x.QId });
            modelBuilder.Entity<StExam>().HasRequired(x => x.Student).WithMany(x => x.exams).HasForeignKey(x => x.StId);
            modelBuilder.Entity<StExam>().HasRequired(x => x.Exam).WithMany(x => x.students).HasForeignKey(x => x.ExId);
            modelBuilder.Entity<StExam>().HasRequired(x => x.Exam).WithMany(x => x.students).HasForeignKey(x => x.ExId);


            //modelBuilder.Entity<QuestionPool>()
            //    .HasMany<Exam>(s => s.examsId)
            //    .WithMany(c => c.questionsId)
            //    .Map(cs =>
            //    {
            //        cs.MapLeftKey("qid");
            //        cs.MapRightKey("exid");
            //        cs.ToTable("QEX");
            //    });


                    modelBuilder.Entity<Student>().HasOptional(b => b.Instructor).WithMany(p => p.students)
            .HasForeignKey(b => b.InstructorId).WillCascadeOnDelete(false);


            modelBuilder.Entity<Instructor>().HasOptional(b => b.Login).WithMany(p => p.instructors)
            .HasForeignKey(b => b.Username).WillCascadeOnDelete();

            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<Login>()
            //            .HasMany(a => a.instructors)
            //            .WithOne(a=>a.Username)
            //            .WillCascadeOnDelete(true);

            //modelBuilder.Entity<Login>()
            //.HasOptional(a => a.students)
            //.WithOptionalDependent()
            //.WillCascadeOnDelete(true);

            //modelBuilder.Entity<Login>()
            //.HasOptional(a => a.managers)
            //.WithOptionalDependent()
            //.WillCascadeOnDelete(true);

            /////// code eng.aya
            //modelBuilder.Entity<Student>().HasOne(b => b.Instructor).WithMany(p => p.Student)
            //    .HasForeignKey(b => b.InstructorId)
            //     .OnDelete(DeleteBehavior.Cascade);
        }
    }



}


