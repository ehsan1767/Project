using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvaluation1.Entites
{
    public class StudentCourse
    {
        public int Id { get; set; }
        public decimal Score { get; set; }
        public DateTime TestDate  { get; set; }


        public int StudentId {  get; set; }
        public Student Student { get; set; }


        public int CourseId {  get; set; }
        public Course Course { get; set; }
    }
}
