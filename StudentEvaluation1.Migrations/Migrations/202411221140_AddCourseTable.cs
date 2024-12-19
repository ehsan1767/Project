using FluentMigrator;
using FluentMigrator.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvaluation1.Migrations.Migrations
{
    [Migration(202411221140)]
    public class _202411221140_AddCourseTable : FluentMigrator.Migration
    {
        public override void Up()
        {
            CreateTable();
        }

        public override void Down()
        {
            Delete.Table("Courses");
        }

        private void CreateTable()
        {
            Create.Table("Courses")
                  .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                  .WithColumn("Name").AsString(50).NotNullable()

                  .WithColumn("TeacherId").AsInt32().NotNullable()
                  .ForeignKey("FK_Courses_Teachers", "Teachers", "Id");

        }
    }
}
