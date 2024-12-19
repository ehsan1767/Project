using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvaluation1.Services.Teachers.Contracts.Dto
{
    public class GetTeacherPerformanceDto
    {
        public int CourseId { get; set; } 
        public string CourseName { get; set; } 
        public int StudentCount { get; set; } 
        public decimal AverageScore { get; set; } 
    }
}
