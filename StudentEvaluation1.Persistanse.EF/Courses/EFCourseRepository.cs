using Microsoft.EntityFrameworkCore;
using StudentEvaluation1.Entites;
using StudentEvaluation1.Services.Courses.contracts;
using StudentEvaluation1.Services.Courses.contracts.Dto;

namespace StudentEvaluation1.Persistanse.EF.Courses
{
    public class EFCourseRepository : CourseRepository
    {
        private readonly DbSet<Course> _courses;

        public EFCourseRepository(EFDataContext context)
        {
            _courses = context.Set<Course>();
        }

        public async Task AddAsync(Course course)
        {
            await _courses.AddAsync(course);
        }

        public async Task<List<GetAllCourseDto>> GetAllAsync()
        => await _courses
                .AsNoTracking()
                .Select(c => new GetAllCourseDto(
                   c.Id,
                   c.Name,
                   c.TeacherId,
                   $"{c.Teacher.Name} {c.Teacher.Family}"
                ))
                .ToListAsync();

        public async Task<bool> ValidateCourseAndTeacherDuplication(
            string courseName,
            int teacherId)
        => await _courses.AnyAsync(_ =>
                        _.Name.Equals(courseName, StringComparison.OrdinalIgnoreCase) &&
                        _.TeacherId == teacherId);


        public async Task<bool> CourseExistsAsync(int courseId)
        => await _courses
                .AsNoTracking()
                .AnyAsync(_ => _.Id == courseId);
    }
}
