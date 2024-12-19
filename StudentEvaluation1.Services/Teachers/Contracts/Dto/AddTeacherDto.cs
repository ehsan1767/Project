using System.ComponentModel.DataAnnotations;

namespace StudentEvaluation1.Services.Teachers.Contracts.Dto
{
    public class AddTeacherDto
    {
        [Required][MaxLength(50)] public string Name { get; set; }

        [Required][MaxLength(50)]public string Family { get; set; }

        [Required][MaxLength(20)]public string PersonnelCode { get; set; }
    }
}
