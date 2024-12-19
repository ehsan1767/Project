using FluentMigrator;
using FluentMigrator.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvaluation1.Migrations.Migrations
{
    [Migration(202411221135)]

    public class _202411221135_AddTeacherTable : FluentMigrator.Migration
    {
        public override void Up()
        {
            CreateTable();
        }

        public override void Down()
        {
            Delete.Table("Teachers");
        }

        private void CreateTable()
        {
            Create.Table("Teachers")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Family").AsString(50).NotNullable()
                .WithColumn("PersonnelCode").AsString(20).NotNullable();
        }
    }
}
