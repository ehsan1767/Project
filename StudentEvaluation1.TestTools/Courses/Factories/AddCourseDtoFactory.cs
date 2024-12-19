using StudentEvaluation1.Services.Courses.contracts.Dto;

namespace StudentEvaluation1.TestTools.Courses.Factories
{
    public static class AddCourseDtoFactory
    {
        public static AddCourseDto Generate(string name,
               int teacherId)
        {
            return
                new AddCourseDto()
                {
                    Name = name,
                    TeacherId = teacherId
                };
        }
    }
}
