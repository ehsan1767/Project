using System.ComponentModel.DataAnnotations;

namespace StudentEvaluation1.Services.StudentCourses.Contracts.Dto
{
    public class AddStudentCourseDto
    {
        [Required] public int StudentId { get; set; }
        [Required] public int CourseId { get; set; }   
        [Required] public decimal Score { get; set; }
        [Required] public DateTime TestDate { get; set; }
    }
}
