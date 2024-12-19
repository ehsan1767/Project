using StudentEvaluation1.Entites;

namespace StudentEvaluation1.Services.StudentCourses.Contracts
{
    public interface StudentCourseRepository
    {
        Task AddAsync(StudentCourse studentCourse);

        Task<bool> IsDuplicatedStudentandCourseAndTestDateAsync(int studentId, int courseId, DateTime testDate);
        Task<bool> IsDuplicatedStudentAndCourseAsync(int studentId, int courseId);
    }
}
