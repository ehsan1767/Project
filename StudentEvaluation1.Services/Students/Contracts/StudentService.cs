using StudentEvaluation1.Services.Courses.contracts.Dto;
using StudentEvaluation1.Services.Students.Contracts.Dto;

namespace StudentEvaluation1.Services.Students.Contracts
{
    public interface StudentService
    {
        Task AddAsync(AddStudentDto dto);

        Task<List<GetAllStudentDto>> GetAll();
        GetStudentAverageDto? GetStudentAverageById(int id);
        Task<List<GetTeacherDto>> GetTeachersByIdAsync(int teacherId);
        List<GetCourseDto> GetCoursesById(int id);
        List<GetStudentOrderByAverage> GetOrderByAverage();

        void DeleteById(int id);
    }
}
