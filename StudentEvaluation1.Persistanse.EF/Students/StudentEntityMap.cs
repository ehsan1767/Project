using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentEvaluation1.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvaluation1.Persistanse.EF.Students
{
    public class StudentEntityMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> _)
        {
            _.ToTable("Students");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).ValueGeneratedOnAdd();

            _.Property(_ => _.Name)
                .IsRequired()
                .HasMaxLength(50);

            _.Property(_ => _.Family)
                .IsRequired()
                .HasMaxLength(50);

            _.Property(_ => _.NationalCode)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("char(10)")
                .IsUnicode(false);
               
            _.HasIndex(_ => _.NationalCode)
                .IsUnique();

        }
    }
}
