using StudentEvaluation1.Services.Courses.contracts.Dto;

namespace StudentEvaluation1.Services.Courses.contracts
{
    public interface CourseService
    {
        public Task AddCourseAsync(AddCourseDto dto);

        public Task<List<GetAllCourseDto>> GetAllAsync();
    }
}
