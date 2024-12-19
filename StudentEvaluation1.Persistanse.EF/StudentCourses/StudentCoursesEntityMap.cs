using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentEvaluation1.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvaluation1.Persistanse.EF.StudentCourses
{
    public class StudentCoursesEntityMap : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> _)
        {
            _.ToTable("StudentCourses");
            _.HasKey(_ => _.Id);
            _.Property(_=>_.Id).ValueGeneratedOnAdd();

            _.Property(_ => _.Score)
                .IsRequired();

            _.Property(_=>_.TestDate)
                .IsRequired();

            _.Property(_=>_.StudentId)
                .IsRequired();

            _.Property(_ => _.CourseId)
                .IsRequired();

            _.HasOne(_ => _.Student)
                .WithMany(_ => _.StudentCourses)
                .HasForeignKey(_ => _.StudentId);

            _.HasOne(_=>_.Course)
                .WithMany(_=>_.StudentCourses)
                .HasForeignKey(_ => _.CourseId);
        }
    }
}
