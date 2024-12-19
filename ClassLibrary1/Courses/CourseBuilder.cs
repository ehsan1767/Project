using StudentEvaluation1.Entites;

namespace StudentEvaluation1.TestTools.Courses
{
    public class CourseBuilder
    {
        private Course _course;

        public CourseBuilder(int teacherId)
        {
            _course = new Course()
            {
                Name = "dummy-name",
                TeacherId = teacherId
            };
        }

        public CourseBuilder WithName(string name)
        {
            _course.Name = name;
            return this;
        }

        public CourseBuilder WithTeacher(Teacher teacher)
        {
            _course.Teacher = teacher;
            return this;
        }

        public Course Build()
        {
            return
                _course;
        }
    }
}
