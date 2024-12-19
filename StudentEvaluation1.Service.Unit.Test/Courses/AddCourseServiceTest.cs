using FluentAssertions;
using StudentEvaluation1.Entites;
using StudentEvaluation1.Services.Courses.contracts;
using StudentEvaluation1.Services.Courses.Exceptions;
using StudentEvaluation1.Services.Teachers.Exceptions;
using StudentEvaluation1.TestTools.Courses.Factories;
using StudentEvaluation1.TestTools.Courses;
using Studentevaluation1.TestTools.Infrastructure.DataBaseConfig;
using Studentevaluation1.TestTools.Teachers;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace StudentEvaluation1.Service.Unit.Test.Courses
{
    public class AddCourseServiceTest : BusinessIntegrationTest
    {
        private readonly CourseService _sut;

        public AddCourseServiceTest()
        {
            _sut = CourseServiceFactory.Create(SetupContext);
        }

        [Fact]
        public async Task AddCourseAsync_ShouldAddCourseProperly()
        {
            var teacher = new TeacherBuilder().Build();
            Context.Save(teacher);

            var dto = AddCourseDtoFactory.Creat(teacherId: teacher.Id);

            await _sut.AddCourseAsync(dto);

            ReadContext.Set<Course>().Should().HaveCount(1)
            .And.ContainSingle(_ =>
            _.Name == dto.Name &&
            _.TeacherId == teacher.Id);
        }

        [Theory]
        [InlineData(0)]
        public async Task Add_throw_is_not_exist_teacher_exception(int invalidId)
        {
            var course = AddCourseDtoFactory.Creat(teacherId: invalidId);

            Func<Task> actual = () => _sut.AddCourseAsync(course);

           await actual.Should().ThrowExactlyAsync<IsNotExistTeacherException>();
        }

        [Fact]
        public void Add_should_throw_DuplicatedCourseAndTeacherException_when_DuplicatedCourseAndTeacher()
        {
            var teacher = new TeacherBuilder().Build();
            var course = new CourseBuilder(teacher.Id)
                .WithTeacher(teacher)
                .Build();
            Context.Save(course);

            var duplicateCourseDto = AddCourseDtoFactory.Creat(teacher.Id);

            Func<Task> actual = () => _sut.AddCourseAsync(duplicateCourseDto);

            actual.Should().ThrowExactlyAsync<DuplicatedCourseAndTeacherException>();
        }

    }
}
