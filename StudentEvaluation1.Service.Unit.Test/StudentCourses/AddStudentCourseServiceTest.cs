using FluentAssertions;
using Studentevaluation1.TestTools.Infrastructure.DataBaseConfig;
using Studentevaluation1.TestTools.Studentcourses.Factorise;
using Studentevaluation1.TestTools.StudentCourses;
using Studentevaluation1.TestTools.StudentCourses.Factorise;
using Studentevaluation1.TestTools.students;
using Studentevaluation1.TestTools.Teachers;
using StudentEvaluation1.Entites;
using StudentEvaluation1.Services.Courses.Exceptions;
using StudentEvaluation1.Services.StudentCourses.Contracts;
using StudentEvaluation1.Services.StudentCourses.Exceptions;
using StudentEvaluation1.Services.Students.Excentions;
using StudentEvaluation1.TestTools.Courses;
using Xunit;

namespace StudentEvaluation1.Service.Unit.Test.StudentCourses
{
    public class AddStudentCourseServiceTest : BusinessIntegrationTest
    {
        private readonly StudentCourseService _sut;

        public AddStudentCourseServiceTest()
        {
            _sut = StudentCourseServiceFactory.Create(SetupContext);
        }

        [Fact]
        public void Add_add_a_student_course_Properly()
        {
            var student = new StudentBuilder().Build();
            Context.Save(student);

            var teacher = new TeacherBuilder().Build();
            Context.Save(teacher);

            var course = new CourseBuilder(teacherId: teacher.Id)
            .WithTeacher(teacher)
            .Build();
            Context.Save(course);

            var dto = AddStudentCourseDtoFactory.Create(
                studentId: student.Id,
                courseId: course.Id);

            _sut.AddAsync(dto);

            ReadContext.Set<StudentCourse>().Should().HaveCount(1)
                .And.ContainSingle(_ =>
                _.StudentId == dto.StudentId &&
                _.CourseId == dto.CourseId &&
                _.Score == dto.Score &&
                _.TestDate == dto.TestDate);
        }

        [Theory]
        [InlineData(0)]
        public async Task Add_throw_student_not_exist_exception(int invalidStudentId)
        {
            var teacher = new TeacherBuilder().Build();
            Context.Save(teacher);
            var course = new CourseBuilder(teacherId: teacher.Id)
            .WithTeacher(teacher)
            .Build();
            Context.Save(course);

            var dto = AddStudentCourseDtoFactory.Create(
                studentId: invalidStudentId,
                courseId: course.Id);

            var actual = async () =>await _sut.AddAsync(dto);

           await actual.Should().ThrowExactlyAsync<StudentNotExistException>();
        }

        [Theory]
        [InlineData(0)]
        public async Task Add_throw_course_not_exist_exception(int invalidCourseId)
        {
            var student = new StudentBuilder().Build();
            Context.Save(student);
            var dto = AddStudentCourseDtoFactory.Create(
                studentId: student.Id,
                courseId: invalidCourseId);

            var actual = async () =>await _sut.AddAsync(dto);

            await actual.Should().ThrowExactlyAsync<CourseNotExistException>();
        }

        [Fact]
        public async void Add_is_duplicated_test_date_exception()
        {
            var student = new StudentBuilder().Build();
            Context.Save(student);

            var teacher = new TeacherBuilder().Build();
            Context.Save(teacher);

            var course = new CourseBuilder(teacherId: teacher.Id)
            .WithTeacher(teacher)
            .Build();
            Context.Save(course);

            var testDate = new DateTime(2024,11,01);
            var studentcource = new StudentCourseBuilder(student.Id, course.Id)
                .WhitStudent(student)
                .whitCourse(course)
                .WhitTestDate(testDate)
                .Build();
            Context.Save(studentcource);

            var dto = AddStudentCourseDtoFactory.Create(
                studentId: student.Id,
                courseId: course.Id,
                testDate: testDate);

            var actual = async () =>await _sut.AddAsync(dto);

          await  actual.Should().ThrowExactlyAsync<IsDuplicatedTestDateException>();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(21)]
        public async Task Add_throw_invalid_score_exception(object invalidScoreobj)
        {
            var invalidScore = Convert.ToDecimal(invalidScoreobj);

            var student = new StudentBuilder().Build();
            Context.Save(student);

            var teacher = new TeacherBuilder().Build();
            Context.Save(teacher);

            var course = new CourseBuilder(teacherId: teacher.Id)
            .WithTeacher(teacher)
            .Build();
            Context.Save(course);

            var dto = AddStudentCourseDtoFactory.Create(
                studentId: student.Id,
                courseId: course.Id,
                score: invalidScore);

            var actual = async () =>await _sut.AddAsync(dto);

           await actual.Should().ThrowExactlyAsync<InvalidScoreException>();
        }

        [Theory]
        [InlineData("2030,01,01")]
        public async Task Add_throw_invalid_test_date_exception(object invaidTestDateobj)
        {
            DateTime invaidTestDate = Convert.ToDateTime(invaidTestDateobj);

            var student = new StudentBuilder().Build();
            Context.Save(student);

            var teacher = new TeacherBuilder().Build();
            Context.Save(teacher);

            var course = new CourseBuilder(teacherId: teacher.Id)
            .WithTeacher(teacher)
            .Build();
            Context.Save(course);

            var dto = AddStudentCourseDtoFactory.Create(
                studentId: student.Id,
                courseId: course.Id,
                testDate: invaidTestDate);

            var actual = async () =>await _sut.AddAsync(dto);

            actual.Should().ThrowExactlyAsync<InvalidTestDateException>();
        }

        [Fact]
        public async Task Add_throw_is_duplicated_student_and_course_exception()
        {
            var student = new StudentBuilder().Build();
            Context.Save(student);
            var teacher = new TeacherBuilder().Build();
            Context.Save(teacher);
            var course1 = new CourseBuilder(teacherId: teacher.Id)
                .WithTeacher(teacher)
                .WithName("ریاضی")
                .Build();
            Context.Save(course1);
            var course2 = new CourseBuilder(teacherId: teacher.Id)
                .WithTeacher(teacher)
                .WithName("ریاضی")
                .Build();
            Context.Save(course2);
            var studentcourse = new StudentCourseBuilder(
                studentId: student.Id,
                courseId: course1.Id)
                .WhitStudent(student)
                .whitCourse(course1)
                .Build();
            Context.Save(studentcourse);

            var dto = AddStudentCourseDtoFactory.Create(
                studentId: student.Id,
                courseId: course2.Id);

            var actual = async () =>await _sut.AddAsync(dto);

          await actual.Should().ThrowExactlyAsync<IsDuplicatedStudentAndCourseException>();
        }
    }
}
