
namespace StudentEvaluation1.Services.Students.Contracts.Dto
{
    public class GetStudentAverageDto
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }    
        public decimal AverageStudent { get; set; }
    }
}
