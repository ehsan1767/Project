using FluentMigrator;
using FluentMigrator.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvaluation1.Migrations.Migrations
{
    [Migration(202411221145)]
    public class _202411221145_AddStudentCourseTable : FluentMigrator.Migration
    {
        public override void Up()
        {
            CreateTable();
        }

        public override void Down()
        {
            Delete.Table("StudentCourses");
        }


        private void CreateTable()
        {
            Create.Table("StudentCourses")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Score").AsDecimal().NotNullable()
                .WithColumn("TestDate").AsDateTime().NotNullable()

                .WithColumn("StudentId").AsInt32().NotNullable()
                .ForeignKey("FK_StudentCourses_Students", "Students", "Id")

                .WithColumn("CourseId").AsInt32().NotNullable()
                .ForeignKey("FK_StudentCourses_Courses", "Courses", "Id");

        }
    }
}
