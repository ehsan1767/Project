using StudentEvaluation1.Services.Students.Contracts.Dto;
using System.Net.Sockets;

namespace Studentevaluation1.TestTools.students.Factories
{
    public static class AddStudentDtoFactory
    {
        public static AddStudentDto Create(
            string? name = null,
            string? family = null,
            string? nationalCode = null)
        {
            return new AddStudentDto
            {
                Name = name ?? "dummy-name",
                Family = family ?? "dummy-family",
                NationalCode = nationalCode ?? "1234567890"
            };
        }
    }
}
