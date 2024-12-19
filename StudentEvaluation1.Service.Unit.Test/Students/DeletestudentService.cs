
using FluentAssertions;
using Studentevaluation1.TestTools.Infrastructure.DataBaseConfig;
using Studentevaluation1.TestTools.students;
using Studentevaluation1.TestTools.students.Factories;
using StudentEvaluation1.Entites;
using StudentEvaluation1.Services.Students.Contracts;
using StudentEvaluation1.Services.Students.Excentions;
using Xunit;

namespace StudentEvaluation1.Service.Unit.Test.Students
{
    public class DeletestudentService : BusinessIntegrationTest
    {
        private StudentService _sut;

        public DeletestudentService()
        {
            _sut = StudentServiceFactory.Create(SetupContext);
        }

        [Fact]
        public void Remove_Delete_a_student_by_id_properly()
        {
            var student = new StudentBuilder().Build();
            Context.Save(student);

            _sut.DeleteById(student.Id);

            ReadContext.Set<Student>().Any().Should().BeFalse();
        }

        [Theory]
        [InlineData(-1)]
        public void Remove_throw_student_not_found_exception(int invalidId)
        {
            var student = new StudentBuilder().Build();
            Context.Save(student);

            var actual = () => _sut.DeleteById(invalidId);

            actual.Should().ThrowExactly<StudentNotFoundException>();
        }
    }
}