using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentEvaluation1.Entites;

namespace StudentEvaluation1.Persistanse.EF.Courses
{
    public class CoursesEntityMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");

            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(_ => _.Name)
                   .IsRequired()
                   .HasMaxLength(50);
                        
            builder.HasOne(_ => _.Teacher)
                   .WithMany(_ => _.Courses)
                   .HasForeignKey(_ => _.TeacherId);
        }
    }
}
