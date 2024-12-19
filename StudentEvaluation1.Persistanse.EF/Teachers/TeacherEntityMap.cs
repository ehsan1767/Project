using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentEvaluation1.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvaluation1.Persistanse.EF.Teachers
{
    public class TeacherEntityMap : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> _)
        {
            _.ToTable("Teachers");
            _.HasKey(_=>_.Id);
            _.Property(_=>_.Id).ValueGeneratedOnAdd();

            _.Property(_ => _.Name)
                .IsRequired()
                .HasMaxLength(50);

            _.Property(_=>_.Family)
                .IsRequired()
                .HasMaxLength(50);

            _.Property(_=>_.PersonnelCode)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
