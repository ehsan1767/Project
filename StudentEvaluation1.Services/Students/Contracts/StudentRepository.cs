using StudentEvaluation1.Entites;
using StudentEvaluation1.Services.Courses.contracts.Dto;
using StudentEvaluation1.Services.Students.Contracts.Dto;

namespace StudentEvaluation1.Services.Students.Contracts
{
    public interface StudentRepository
    {
        Task AddAsync(Student student);
        void Delete(Student student);

        Task<List<GetAllStudentDto>> GetAll();
        Task<List<GetTeacherDto>> GetTeachersByIdAsync(int StudentId);
        GetStudentAverageDto? GetStudentAverageById(int id);
        List<GetCourseDto> GetCoursesById(int id);
        List<GetStudentOrderByAverage> GetOrderByAverage();

        bool IsDuplicatedNationalCode(string nationalCode);

        Task<bool> StudentExistAsync(int idstudentId);

        Student? FindById(int id);


    }
}
