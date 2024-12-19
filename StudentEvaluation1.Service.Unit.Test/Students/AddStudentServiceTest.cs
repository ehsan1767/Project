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
    public class AddStudentServiceTest : BusinessIntegrationTest
    {
        private readonly StudentService _sut;
        public AddStudentServiceTest()
        {
            _sut = StudentServiceFactory.Create(SetupContext);
        }

        [Fact]
        public async Task AddStudentAsync_ShouldAddStudentProperly()
        {
            var dto = AddStudentDtoFactory.Create();

            await _sut.AddAsync(dto);

            ReadContext.Set<Student>().Should().HaveCount(1)
                .And.ContainSingle(_ =>
                _.Name == dto.Name &&
                _.Family == dto.Family &&
                _.NationalCode == dto.NationalCode);
        }

        [Fact]
        public async Task Add_should_throw_IsDuplicatedNationalCodeException_when_StudentIsDuplicated()
        {
            //Arrange
            var existingStudent = new StudentBuilder().Build();
            Context.Save(existingStudent);
            //Creat a Dto
            var duplicatedStudentDto = AddStudentDtoFactory.Create();

            //Act
            Func<Task> actual = () => _sut.AddAsync(duplicatedStudentDto);

            //Assert
            await actual.Should().ThrowExactlyAsync<IsDuplicatedNationalCodeException>();
        }

        [Theory]
        [InlineData("1234567890")]
        public async Task Add_should_NotThrowException_when_NationalCodeIsValid(string validNationalCode)
        {
            //Arrange
            var Studentdto = AddStudentDtoFactory.Create(nationalCode: validNationalCode);

            //Act
            Func<Task> actual = () => _sut.AddAsync(Studentdto);

            //Assert
            await actual.Should().NotThrowAsync();
        }

        [Theory]
        [InlineData("12345678901")]
        [InlineData("123")]
        [InlineData(null)]
        [InlineData("")]
        public async Task Add_should_throw_InvalidNationalCodeException_when_InvalidNationalCode(string? invalidNationalCode)
        {
            var dto = AddStudentDtoFactory.Create(nationalCode: invalidNationalCode);

            Func<Task> actual =  () =>  _sut.AddAsync(dto);

            await actual.Should().ThrowExactlyAsync<InvalidNationalCodeException>();
        }

    }
}
