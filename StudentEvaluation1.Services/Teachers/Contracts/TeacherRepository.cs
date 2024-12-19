using StudentEvaluation1.Entites;
using StudentEvaluation1.Services.Teachers.Contracts.Dto;

namespace StudentEvaluation1.Services.Teachers.Contracts
{
    public interface TeacherRepository
    {
        Task AddAsync(Teacher teacher);

        public List<GetAllTeacherDto> GetAll();
        public List<GetTeacherPerformanceDto> GetPerformanceById(int id);

        bool IsExistByPersonnelCode(string personnelCode);
        Task<bool> TeacherExistAsync(int teacherId);
    }
}
