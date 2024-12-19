using StudentEvaluation1.Services.Students.Contracts;
using Studentevaluation1.TestTools.students.Factories;
using FluentAssertions;
using Studentevaluation1.TestTools.Infrastructure.DataBaseConfig;
using Studentevaluation1.TestTools.students;
using Xunit;
using StudentEvaluation1.TestTools.Courses;
using Studentevaluation1.TestTools.Teachers;
using Studentevaluation1.TestTools.StudentCourses;

namespace StudentEvaluation1.Service.Unit.Test.Students
{
    public class GetStudentServiceTest : BusinessIntegrationTest
    {
        private readonly StudentService _sut;
        public GetStudentServiceTest()
        {
            _sut = StudentServiceFactory.Create(SetupContext);
        }

        [Fact]
        public async void Get_get_all_student_properly()
        {
            var student1 = new StudentBuilder().Build();
            Context.Save(student1);

            var student2 = new StudentBuilder()
                .WhitName("dummy-name2")
                .WhitFamily("dummy-family2")
                .WhitNationalCode("dummy2")
                .Build();
            Context.Save(student2);

            var actual =await _sut.GetAll();

            actual.Should().HaveCount(2)
                .And.ContainSingle(_ =>
                _.Name == student1.Name &&
                _.Family == student1.Family &&
                _.NationalCode == student1.NationalCode)
                .And.ContainSingle(_ =>
                _.Name == student2.Name &&
                _.Family == student2.Family &&
                _.NationalCode == student2.NationalCode);
        }

        [Fact]
        public void Get_get_courses_by_id_properly()
        {
            var student = new StudentBuilder().Build();
            Context.Save(student);
            var teacher = new TeacherBuilder().Build();
            Context.Save(teacher);
            var course1 = new CourseBuilder(teacherId: teacher.Id)
                .WithName("Math")
                .WithTeacher(teacher)
                .Build();
            Context.Save(course1);

            var course2 = new CourseBuilder(teacherId: teacher.Id)
                .WithName("Phicycs")
                .WithTeacher(teacher)
                .Build();
            Context.Save(course2);

            var studentCourse1 = new StudentCourseBuilder(
                studentId: student.Id,
                courseId: course1.Id)
                .whitCourse(course1)
                .WhitStudent(student)
                .Build();
            Context.Save(studentCourse1);

            var studentCourse2 = new StudentCourseBuilder(
               studentId: student.Id,
               courseId: course2.Id)
               .whitCourse(course2)
               .WhitStudent(student)
               .Build();
            Context.Save(studentCourse2);

            var actual = _sut.GetCoursesById(student.Id);

            actual.Should().HaveCount(2)
                .And.ContainSingle(_ =>
                _.Id == course1.Id &&
                _.Name == "Math")
                .And.ContainSingle(_ =>
                _.Id == course2.Id &&
                _.Name == "Phicycs");
        }
        [Theory]
        [InlineData(-1)]
        public void Get_get_courses_by_id_return_empty_properly(int invalidId)
        {
            var actual = _sut.GetCoursesById(invalidId);

            actual.Should().BeEmpty();
        }

        [Fact]
        public async Task Get_get_teachers_by_id_properly()
        {
            var student = new StudentBuilder().Build();
            Context.Save(student);
            var teacher1 = new TeacherBuilder().Build();
            Context.Save(teacher1);
            var teacher2 = new TeacherBuilder().Build();
            Context.Save(teacher2);
            var course1 = new CourseBuilder(teacherId: teacher1.Id)
                .WithName("Math")
                .WithTeacher(teacher1)
                .Build();
            Context.Save(course1);

            var course2 = new CourseBuilder(teacherId: teacher2.Id)
                .WithName("Phicycs")
                .WithTeacher(teacher2)
                .Build();
            Context.Save(course2);

            var studentCourse1 = new StudentCourseBuilder(
                studentId: student.Id,
                courseId: course1.Id)
                .whitCourse(course1)
                .WhitStudent(student)
                .Build();
            Context.Save(studentCourse1);

            var studentCourse2 = new StudentCourseBuilder(
               studentId: student.Id,
               courseId: course2.Id)
               .whitCourse(course2)
               .WhitStudent(student)
               .Build();
            Context.Save(studentCourse2);

            var actual = await _sut.GetTeachersByIdAsync(student.Id);

            actual.Should().HaveCount(2)
                .And.ContainSingle(_ =>
                _.TeacherId == teacher1.Id &&
                _.Name == teacher1.Name &&
                _.Family == teacher1.Family &&
                _.PersonnelCode == teacher1.PersonnelCode)
                .And.ContainSingle(_ =>
                _.TeacherId == teacher2.Id &&
                _.Name == teacher2.Name &&
                _.Family == teacher2.Family &&
                _.PersonnelCode == teacher2.PersonnelCode);
        }
        [Theory]
        [InlineData(-1)]
        public async Task Get_get_teachers_by_id_return_empty_properly(int invalidId)
        {
            var actual = await _sut.GetTeachersByIdAsync(invalidId);

            actual.Should().BeEmpty();
        }

        [Fact]
        public void Get_get_student_average_by_id_properly()
        {
            var student = new StudentBuilder().Build();
            Context.Save(student);

            var teacher = new TeacherBuilder().Build();
            var course1 = new CourseBuilder(teacherId: teacher.Id)
                .WithTeacher(teacher)
                .WithName("Math")
                .Build();
            Context.Save(course1);

            var course2 = new CourseBuilder(teacherId: teacher.Id)
                .WithTeacher(teacher)
                .WithName("Physics")
                .Build();
            Context.Save(course2);

            var studentCourse1 = new StudentCourseBuilder(
                studentId: student.Id, courseId: course1.Id)
                .whitCourse(course1)
                .WhitStudent(student)
                .WhitScore(19m)
                .Build();
            Context.Save(studentCourse1);

            var studentCourse2 = new StudentCourseBuilder(
              studentId: student.Id, courseId: course2.Id)
              .whitCourse(course2)
              .WhitStudent(student)
              .WhitScore(15m)
              .Build();
            Context.Save(studentCourse2);

            var actual = _sut.GetStudentAverageById(student.Id);

            actual.Should().NotBeNull();
            actual.Name.Should().Be(student.Name);
            actual.Family.Should().Be(student.Family);
            actual.NationalCode.Should().Be(student.NationalCode);
            actual.AverageStudent.Should().Be(17m);
        }
        [Fact]
        public void Get_get_student_average_by_id_return_average_equal_zero_properly()
        {
            var student1 = new StudentBuilder()
                .WhitName("ehsan")
                .WhitFamily("salahi")
                .WhitNationalCode("1020")
                .Build();
            Context.Save(student1);

            var student = new StudentBuilder().Build();
            Context.Save(student);

            var teacher = new TeacherBuilder().Build();
            var course = new CourseBuilder(teacherId: teacher.Id)
                .WithTeacher(teacher)
                .Build();
            Context.Save(course);

            var studentCourse = new StudentCourseBuilder(
                studentId: student.Id,
                courseId: course.Id)
                .whitCourse(course)
                .WhitStudent(student)
                .WhitScore(19)
                .Build();
            Context.Save(studentCourse);

            var actual = _sut.GetStudentAverageById(student1.Id);

            actual.Should().NotBeNull();
            actual.Name.Should().Be("ehsan");
            actual.Family.Should().Be("salahi");
            actual.NationalCode.Should().Be("1020");
            actual.AverageStudent.Should().Be(0m);
        }

        [Theory]
        [InlineData(-1)]
        public void Get_get_student_average_by_id_return_null_properly(int invalidId)
        {
            var actual = _sut.GetStudentAverageById(invalidId);

            actual.Should().BeNull();
        }

        [Fact]
        public void Get_get_order_by_average_properly()
        {
            var student1 = new StudentBuilder()
                .WhitName("ehsan")
                .Build();
            Context.Save(student1);
            var student2 = new StudentBuilder()
                .WhitName("ali")
                .Build();
            Context.Save(student2);
            var student3 = new StudentBuilder()
                .WhitName("sadegh")
                .Build();
            Context.Save(student3);
            var teacher = new TeacherBuilder().Build();
            var course = new CourseBuilder(teacherId: teacher.Id)
                .WithTeacher(teacher)
                .Build();
            Context.Save(course);

            var studentCourse1 = new StudentCourseBuilder(
               studentId: student1.Id, courseId: course.Id)
               .WhitStudent(student1)
               .whitCourse(course)
               .WhitScore(17m)
               .Build();
            Context.Save(studentCourse1);
            var studentCourse2 = new StudentCourseBuilder(
              studentId: student2.Id, courseId: course.Id)
              .WhitStudent(student2)
              .whitCourse(course)
              .WhitScore(20m)
              .Build();
            Context.Save(studentCourse2);
            var studentCourse3 = new StudentCourseBuilder(
              studentId: student3.Id, courseId: course.Id)
              .WhitStudent(student3)
              .whitCourse(course)
              .WhitScore(19m)
              .Build();
            Context.Save(studentCourse3);

            var actual = _sut.GetOrderByAverage();

            actual.Should().HaveCount(3);
            actual[0].Name.Should().Be("ali");
            actual[1].Name.Should().Be("sadegh");
            actual[2].Name.Should().Be("ehsan");
        }

        [Fact]
        public void Get_get_order_by_average_return_average_equal_zero_properly()
        {
            var student = new StudentBuilder()
               .WhitName("ehsan")
               .Build();
            Context.Save(student);
            var teacher = new TeacherBuilder().Build();
            var course = new CourseBuilder(teacherId: teacher.Id)
                .WithTeacher(teacher)
                .Build();
            Context.Save(course);
           

            var actual = _sut.GetOrderByAverage();

            actual.Should().HaveCount(1)
            .And.ContainSingle(_ => _.StudentAverage == 0m);
        }
    }
}
