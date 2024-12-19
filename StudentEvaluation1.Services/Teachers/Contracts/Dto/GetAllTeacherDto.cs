using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvaluation1.Services.Teachers.Contracts.Dto
{
    public class GetAllTeacherDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string PersonnelCode { get; set; }
    }
}
