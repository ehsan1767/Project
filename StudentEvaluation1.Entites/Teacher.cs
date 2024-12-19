
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentEvaluation1.Entites
{
    public class Teacher
    {
        public Teacher()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string PersonnelCode { get; set; }


        //[InverseProperty("Teacher")]
        public HashSet<Course> Courses { get; set; }
    }
}
