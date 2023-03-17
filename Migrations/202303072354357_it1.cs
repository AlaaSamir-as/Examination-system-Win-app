namespace ExaminationSytem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class it1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Exams", "TotalTime", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exams", "TotalTime", c => c.String());
        }
    }
}
