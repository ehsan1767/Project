using System.ComponentModel.DataAnnotations;

namespace StudentEvaluation1.Services.Courses.contracts.Dto
{
    public class AddCourseDto
    {
        [Required][MaxLength(50)] public string Name { get; set; }

        [Required] public int TeacherId { get; set; }
    }
}
