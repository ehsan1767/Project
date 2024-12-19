using StudentEvaluation1.Entites;

namespace Studentevaluation1.TestTools.StudentCourses
{
    public class StudentCourseBuilder
    {
        private StudentCourse _studentCourse;

        public StudentCourseBuilder(
              int studentId,
              int courseId)
        {
            _studentCourse = new StudentCourse()
            {
                StudentId = studentId,
                CourseId = courseId,
                Score = 0m,
                TestDate = new DateTime(2024,12,01)
            };
        }

        public StudentCourseBuilder WhitStudent(Student student)
        {
            _studentCourse.Student = student;
            return this;
        }
        public StudentCourseBuilder whitCourse(Course course)
        {
            _studentCourse.Course = course;
            return this;
        }
        public StudentCourseBuilder WhitScore(decimal score)
        {
            _studentCourse.Score = score;
            return this;
        }

        public StudentCourseBuilder WhitTestDate(DateTime tesDate)
        {
            _studentCourse.TestDate = tesDate;
            return this;
        }

        public StudentCourse Build()
        {
            return _studentCourse;
        }
    }
}


