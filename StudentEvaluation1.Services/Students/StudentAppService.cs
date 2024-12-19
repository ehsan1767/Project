using StudentEvaluation1.Entites;
using StudentEvaluation1.Services.Contracts;
using StudentEvaluation1.Services.Courses.contracts.Dto;
using StudentEvaluation1.Services.Students.Contracts;
using StudentEvaluation1.Services.Students.Contracts.Dto;
using StudentEvaluation1.Services.Students.Excentions;

namespace StudentEvaluation1.Services.Students
{
    public class StudentAppService : StudentService
    {
        private readonly StudentRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public StudentAppService(
            StudentRepository studentRepository,
            UnitOfWork unitOfWork)
        {
            _repository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(AddStudentDto dto)
        {
            IsValidNationalCode(dto.NationalCode);
            IsDuplicatedNationalCode(dto.NationalCode);

            var student = new Student
            {
                Name = dto.Name,
                Family = dto.Family,
                NationalCode = dto.NationalCode
            };

            await _repository.AddAsync(student);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<GetAllStudentDto>> GetAll()
        {
            return
               await _repository.GetAll();
        }
        public async Task<List<GetTeacherDto>> GetTeachersByIdAsync(int teacherId)
        {
            return await _repository.GetTeachersByIdAsync(teacherId);
        }
        public List<GetCourseDto> GetCoursesById(int id)
        {
            return
                _repository.GetCoursesById(id);
        }
        public GetStudentAverageDto? GetStudentAverageById(int id)
        {
            return
                 _repository.GetStudentAverageById(id);

        }
        public List<GetStudentOrderByAverage> GetOrderByAverage()
        {
            return
                _repository.GetOrderByAverage();
        }

        public void DeleteById(int id)
        {
            var student = _repository.FindById(id);
            IsExistStudent(student);

            _repository.Delete(student);
            _unitOfWork.Save();
        }

        private void IsValidNationalCode(string nationalCode)
        {
            var isValid = (string.IsNullOrEmpty(nationalCode) ||
                           nationalCode.Length != 10);

            if (isValid)
                throw new InvalidNationalCodeException();
        }
        private void IsDuplicatedNationalCode(string nationalCode)
        {
            var isDuplicated = _repository.IsDuplicatedNationalCode(nationalCode);

            if (isDuplicated)
                throw new IsDuplicatedNationalCodeException();
        }

        private void IsExistStudent(Student? student)
        {
            if (student is null)
                throw new StudentNotFoundException();
        }
    }
}
