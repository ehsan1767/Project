using FluentAssertions;
using Studentevaluation1.TestTools.Infrastructure.DataBaseConfig;
using Studentevaluation1.TestTools.Teachers;
using Studentevaluation1.TestTools.Teachers.Factories;
using StudentEvaluation1.Entites;
using StudentEvaluation1.Services.Teachers.Contracts;
using StudentEvaluation1.Services.Teachers.Exceptions;
using StudentEvaluation1.TestTools.Teachers.Factories;
using Xunit;

namespace StudentEvaluation1.Service.Unit.Test.Teachers
{
    public class AddTeacherSrviceTest : BusinessIntegrationTest
    {
        private readonly TeacherService _sut;
        public AddTeacherSrviceTest()
        {
            _sut = TeacherServiceFactory.Create(SetupContext);
        }

        [Fact]
        public void Add_add_a_teacher_properly()
        {
            var dto = AddTeacherDtoFactory.Create();

            _sut.Add(dto);

            ReadContext.Set<Teacher>().Should().HaveCount(1)
                .And
                .ContainSingle(_ =>
                _.Name == dto.Name &&
                _.Family == dto.Family &&
                _.PersonnelCode == dto.PersonnelCode);
        }

        [Fact]
        public void Add_is_duplicated_personnel_code_exception()
        {
            var teacher = new TeacherBuilder()
                .WhitPersonnelCode("123")
                .Build();
            Context.Save(teacher);
            var dto = AddTeacherDtoFactory.Create(PersonnelCode:"123");

            var actual = () => _sut.Add(dto);

            actual.Should().ThrowExactly<IsDuplicatedPersonnelCodeException>();
        }

    
    }

}
