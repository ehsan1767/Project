using Studentevaluation1.TestTools.Teachers;
using StudentEvaluation1.Services.Teachers.Contracts;
using Studentevaluation1.TestTools.Teachers.Factories;
using Xunit;
using Studentevaluation1.TestTools.Infrastructure.DataBaseConfig;
using FluentAssertions;
using Studentevaluation1.TestTools.students;
using StudentEvaluation1.TestTools.Courses;
using Studentevaluation1.TestTools.StudentCourses;

namespace StudentEvaluation1.Service.Unit.Test.Teachers
{
    public class GetTeacherSrviceTest : BusinessIntegrationTest
    {
        private readonly TeacherService _sut;
        public GetTeacherSrviceTest()
        {
            _sut = TeacherServiceFactory.Create(SetupContext);
        }

        [Fact]
        public void Get_get_all_teacher_properly()
        {
            var teacher1 = new TeacherBuilder().Build();
            Context.Save(teacher1);

            var teacher2 = new TeacherBuilder()
                .WhitName("dummy-name2")
                .WhitFamily("dummy-name2")
                .WhitPersonnelCode("dummy2")
                .Build();
            Context.Save(teacher2);

            var actual = _sut.GetAll();

            actual.Should().HaveCount(2)
                .And.ContainSingle(_ =>
                _.Name == teacher1.Name &&
                _.Family == teacher1.Family &&
                _.PersonnelCode == teacher1.PersonnelCode)
                .And
                .ContainSingle(_ =>
                _.Name == teacher2.Name &&
                _.Family == teacher2.Family &&
                _.PersonnelCode == teacher2.PersonnelCode);
        }
        [Fact]
        public void Get_get_performance_by_Id_properly()
        {
            var student1 = new StudentBuilder().Build();
            Context.Save(student1);

            var student2 = new StudentBuilder().Build();
            Context.Save(student2);

            var teacher = new TeacherBuilder().Build();
            Context.Save(teacher);

            var course1 = new CourseBuilder(teacherId: teacher.Id)
                .WithTeacher(teacher)
                .WithName("Math")
                .Build();
            Context.Save(course1);

            var course2 = new CourseBuilder(teacherId: teacher.Id)
                .WithTeacher(teacher)
                .WithName("physics")
                .Build();
            Context.Save(course2);

            var studentCourse1 = new StudentCourseBuilder(
                studentId: student1.Id,
                courseId: course1.Id)
                .WhitStudent(student1)
                .whitCourse(course1)
                .WhitScore(15)
                .Build();
            Context.Save(studentCourse1);

            var studentCourse2 = new StudentCourseBuilder(
               studentId: student1.Id,
               courseId: course2.Id)
               .WhitStudent(student1)
               .whitCourse(course2)
               .WhitScore(20)
               .Build();
            Context.Save(studentCourse2);

            var studentCourse3 = new StudentCourseBuilder(
               studentId: student1.Id,
               courseId: course2.Id)
               .WhitStudent(student1)
               .whitCourse(course2)
               .WhitScore(19)
               .Build();
            Context.Save(studentCourse3);

            var actual = _sut.GetPerformanceById(teacher.Id);

            actual.Should().HaveCount(2)
                .And.ContainSingle(_ =>
                _.CourseId == course1.Id &&
                _.CourseName == course1.Name &&
                _.StudentCount == 1 &&
                _.AverageScore == 15m)
                .And.ContainSingle(_ =>
                _.CourseId == course2.Id &&
                _.CourseName == course2.Name &&
                _.StudentCount == 2 &&
                _.AverageScore == 19.5m);

            //actual.FirstOrDefault(_ =>
            //_.CourseId == course1.Id &&
            //_.CourseName == course1.Name &&
            //_.StudentCount == 1 &&
            //_.AverageScore == 15m);

            //actual.FirstOrDefault(_ =>
            //      _.CourseId == course2.Id &&
            //      _.CourseName == course2.Name &&
            //      _.StudentCount == 2 &&
            //      _.AverageScore == 16m);

        }
    }
}