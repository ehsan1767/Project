using StudentEvaluation1.Entites;

namespace Studentevaluation1.TestTools.students
{
    public class StudentBuilder
    {
        private Student _student;

        public StudentBuilder()
        {
            _student = new Student
            {
                Name = "dummy-name",
                Family = "dummy-family",
                NationalCode = "1234567890"
            };
        }

        public StudentBuilder WhitName(string name)
        {
            _student.Name = name;
            return this;
        }

        public StudentBuilder WhitFamily(string family)
        {
            _student.Family = family;
            return this;
        }

        public StudentBuilder WhitNationalCode(string nationalCode)
        {
            _student.NationalCode = nationalCode;
            return this;
        }

        public Student Build()
        {
            return _student;
        }
    }
}
