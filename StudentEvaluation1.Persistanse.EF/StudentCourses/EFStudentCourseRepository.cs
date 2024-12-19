using Microsoft.EntityFrameworkCore;
using StudentEvaluation1.Entites;
using StudentEvaluation1.Services.StudentCourses.Contracts;

namespace StudentEvaluation1.Persistanse.EF.StudentCourses
{
    public class EFStudentCourseRepository : StudentCourseRepository
    {
        private readonly DbSet<StudentCourse> _studentCourses;
        private readonly DbSet<Course> _Courses;

        public EFStudentCourseRepository(EFDataContext context)
        {
            _studentCourses = context.Set<StudentCourse>();
            _Courses = context.Set<Course>();
        }

        public async Task AddAsync(StudentCourse studentCourse)
        {
            await _studentCourses.AddAsync(studentCourse);
        }

        public async Task<bool> IsDuplicatedStudentandCourseAndTestDateAsync(int studentId, int courseId, DateTime testDate)
        {
            return await _studentCourses.AnyAsync(_ =>
                         _.StudentId == studentId &&
                         _.Course.Id == courseId &&
                         _.TestDate.Date == testDate.Date);
        }
        public async Task<bool> IsDuplicatedStudentAndCourseAsync(int studentId, int courseId)
        {
            var courseName = _Courses.First(_ => _.Id == courseId).Name;

            return await _studentCourses.AnyAsync(_ =>
                         _.StudentId == studentId &&
                         _.Course.Id != courseId &&
                         _.Course.Name == courseName);
        }
    }
}

