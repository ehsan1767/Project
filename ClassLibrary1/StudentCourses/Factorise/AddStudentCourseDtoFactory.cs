using StudentEvaluation1.Services.StudentCourses.Contracts.Dto;

namespace Studentevaluation1.TestTools.Studentcourses.Factorise
{
    public static class AddStudentCourseDtoFactory
    {
        public static AddStudentCourseDto Create(
            int courseId,
            int studentId,
            decimal? score = null,
            DateTime? testDate = null)
        {
            return new AddStudentCourseDto
            {
                CourseId = courseId,
                StudentId = studentId,
                Score = score ?? 0m,
                TestDate = testDate ?? new DateTime(2024,12,01) 
            };
        }
    }
}
