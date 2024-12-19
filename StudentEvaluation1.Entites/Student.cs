
namespace StudentEvaluation1.Entites
{
    public class Student
    {
        public Student()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }

        public HashSet<StudentCourse> StudentCourses { get; set; }

    }
}
