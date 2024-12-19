using StudentEvaluation1.Entites;

namespace StudentEvaluation1.TestTools.Teachers.Factories
{
    public static class TeacherFactory
    {
        public static Teacher Generate (string name,
            string family, string PersonnelCode)
        {
            return
                new Teacher()
                {
                    Name = name,
                    Family = family,
                    PersonnelCode = PersonnelCode
                };
        }
    }
}
