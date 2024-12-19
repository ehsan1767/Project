using StudentEvaluation1.Entites;
using StudentEvaluation1.Services.Contracts;
using StudentEvaluation1.Services.Teachers.Contracts;
using StudentEvaluation1.Services.Teachers.Contracts.Dto;
using StudentEvaluation1.Services.Teachers.Exceptions;

namespace StudentEvaluation1.Services.Teachers
{
    public class TeacherAppService : TeacherService
    {
        private readonly TeacherRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public TeacherAppService(
           TeacherRepository teacherRepository,
           UnitOfWork unitOfWork)
        {
            _repository = teacherRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddTeacherDto dto)
        {
            IsDuplicatedPersonnelCode(dto.PersonnelCode);

            var techer = new Teacher
            {
                Name = dto.Name,
                Family = dto.Family,
                PersonnelCode = dto.PersonnelCode
            };

            _repository.AddAsync(techer);
            _unitOfWork.Save();
        }

        public List<GetAllTeacherDto> GetAll()
        {
            return
                _repository.GetAll();
        }
        public List<GetTeacherPerformanceDto> GetPerformanceById(int id)
        {
            return
                _repository.GetPerformanceById(id);
        }

        private void IsDuplicatedPersonnelCode(string personnelCode)
        {
            var isDuplicated = _repository.IsExistByPersonnelCode(personnelCode);
            if (isDuplicated)
            {
                throw new IsDuplicatedPersonnelCodeException();
            }
        }
    }
}

