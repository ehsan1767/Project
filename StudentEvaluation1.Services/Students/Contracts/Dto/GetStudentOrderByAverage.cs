using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvaluation1.Services.Students.Contracts.Dto
{
    public class GetStudentOrderByAverage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }
        public decimal StudentAverage { get; set; }
    }
}
