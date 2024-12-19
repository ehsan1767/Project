using FluentAssertions;
using Studentevaluation1.TestTools.Infrastructure.DataBaseConfig;
using Studentevaluation1.TestTools.Teachers;
using StudentEvaluation1.Services.Courses.contracts;
using StudentEvaluation1.TestTools.Courses;
using StudentEvaluation1.TestTools.Courses.Factories;
using Xunit;

namespace StudentEvaluation1.Service.Unit.Test.Courses
{
    public class GetCourseServiceTest : BusinessIntegrationTest
    {
        private readonly CourseService _sut;

        public GetCourseServiceTest()
        {
            _sut = CourseServiceFactory.Create(SetupContext);
        }

        [Fact]
        public async void Get_get_all_course_properly()
        {
            var teacher = new TeacherBuilder().Build();
            var course1 = new CourseBuilder(teacher.Id)
                .WithTeacher(teacher)
                .Build();
            Context.Save(course1);

            var course2 = new CourseBuilder(teacher.Id)
                .WithName("dummy-name2")
                .WithTeacher(teacher)
                .Build();
            Context.Save(course2);

            var actual = await _sut.GetAllAsync();

            actual.Should().HaveCount(2)
                .And.ContainSingle(_ =>
                _.Id == course1.Id &&
                _.Name == course1.Name)
                .And.ContainSingle(_ =>
                _.Id == course2.Id &&
                _.Name == course2.Name);
        }

    }
}
