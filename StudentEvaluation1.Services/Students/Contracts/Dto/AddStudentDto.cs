using System.ComponentModel.DataAnnotations;

namespace StudentEvaluation1.Services.Students.Contracts.Dto
{
    public class AddStudentDto
    {
        [Required][MaxLength(50)]public string Name { get; set; }

        [Required][MaxLength(50)]public string Family { get; set; }

        [Required] [StringLength(10, MinimumLength = 10)]
        public string NationalCode { get; set; }
    }
}
