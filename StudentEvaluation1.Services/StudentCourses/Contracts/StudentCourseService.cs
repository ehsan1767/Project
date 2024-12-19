using StudentEvaluation1.Services.StudentCourses.Contracts.Dto;

namespace StudentEvaluation1.Services.StudentCourses.Contracts
{
    public interface StudentCourseService
    {
        Task AddAsync(AddStudentCourseDto dto);
    }
}
