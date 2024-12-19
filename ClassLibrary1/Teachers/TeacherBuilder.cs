using StudentEvaluation1.Entites;

namespace Studentevaluation1.TestTools.Teachers
{
    public class TeacherBuilder
    {
        private Teacher _teacher;

        public TeacherBuilder()
        {
            _teacher = new Teacher
            {
                Name = "dummy-name",
                Family = "dummy-family",
                PersonnelCode = "dummy"
            };
        }

        public TeacherBuilder WhitName(string name)
        {
            _teacher.Name = name;
            return this;
        }

        public TeacherBuilder WhitFamily(string family)
        {
            _teacher.Family = family;
            return this;
        }

        public TeacherBuilder WhitPersonnelCode(string personnelCode)
        {
            _teacher.PersonnelCode = personnelCode;
            return this;
        }

        public Teacher Build()
        {
            return _teacher;
        }
    }
}
