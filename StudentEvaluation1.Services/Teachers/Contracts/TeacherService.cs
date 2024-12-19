using StudentEvaluation1.Services.Teachers.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvaluation1.Services.Teachers.Contracts
{
    public interface TeacherService
    {
        void Add(AddTeacherDto dto);

        public List<GetAllTeacherDto> GetAll();

        public List<GetTeacherPerformanceDto> GetPerformanceById(int id);
    }
}
