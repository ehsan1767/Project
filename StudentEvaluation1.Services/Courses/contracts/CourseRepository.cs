using StudentEvaluation1.Entites;
using StudentEvaluation1.Services.Courses.contracts.Dto;

namespace StudentEvaluation1.Services.Courses.contracts
{
    public interface CourseRepository
    {
        public Task AddAsync(Course course);

        public Task<List<GetAllCourseDto>> GetAllAsync();

        Task<bool> ValidateCourseAndTeacherDuplication(string courseName, int teacherId);

        Task<bool> CourseExistsAsync(int courseId);
    }
}
