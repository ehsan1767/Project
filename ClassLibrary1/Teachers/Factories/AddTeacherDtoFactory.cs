using StudentEvaluation1.Entites;
using StudentEvaluation1.Services.Teachers.Contracts.Dto;

namespace StudentEvaluation1.TestTools.Teachers.Factories
{
    public static class AddTeacherDtoFactory
    {
        public static AddTeacherDto Create (
            string? name = null,
            string? family = null,
            string? PersonnelCode = null)
        {
            return
                new AddTeacherDto()
                {
                    Name = name ?? "dummy-name",
                    Family = family ?? "dummy-family",
                    PersonnelCode = PersonnelCode ?? "dummy"
                };
        }
    }
}
