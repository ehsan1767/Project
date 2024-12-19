using FluentMigrator;

namespace StudentEvaluation1.Migrations.Migrations
{
    [Migration(202411221130)]
    public class _202411221130_AddStudentTable : FluentMigrator.Migration
    {
        public override void Up()
        {
            CreatTable();
        }

        public override void Down()
        {
            Delete.Table("Students");
        }

        private void CreatTable()
        {
            Create.Table("Students")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Family").AsString(50).NotNullable()
                .WithColumn("NationalCode").AsString(10).NotNullable();
        }
    }
}
