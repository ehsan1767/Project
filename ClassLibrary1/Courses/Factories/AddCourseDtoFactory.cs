using StudentEvaluation1.Services.Courses.contracts.Dto;

namespace StudentEvaluation1.TestTools.Courses.Factories
{
    public static class AddCourseDtoFactory
    {
        public static AddCourseDto Creat(
            int teacherId,
            string? name = null)
        {
            return
                new AddCourseDto()
                {
                    Name = name ?? "dummy-name",
                    TeacherId = teacherId
                };
        }
    }
}
