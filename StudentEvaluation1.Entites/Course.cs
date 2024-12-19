
namespace StudentEvaluation1.Entites
{
    public class Course
    {
        public Course()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }


        //[ForeignKey("TeacherId")]
        public int TeacherId {  get; set; }
        //[JsonIgnore]
        public Teacher Teacher { get; set; }

        public HashSet<StudentCourse> StudentCourses { get; set; }
    }
}
