using StudentEvaluation1.Entites;
using StudentEvaluation1.Services.Contracts;
using StudentEvaluation1.Services.Courses.contracts;
using StudentEvaluation1.Services.Courses.contracts.Dto;
using StudentEvaluation1.Services.Courses.Exceptions;
using StudentEvaluation1.Services.Teachers.Contracts;
using StudentEvaluation1.Services.Teachers.Exceptions;

namespace StudentEvaluation1.Services.Courses
{
    public class CourseAppServic : CourseService
    {
        private readonly CourseRepository _repository;
        private readonly TeacherRepository _teacherRepository;
        private readonly UnitOfWork _unitOfWork;

        public CourseAppServic(UnitOfWork unitOfWork,
            CourseRepository courseRepository,
            TeacherRepository teacherRepository)

        {
            _repository = courseRepository;
            _teacherRepository = teacherRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddCourseAsync(AddCourseDto dto)
        {
            await EnsureTeacherExistAsync(dto.TeacherId);
            await ValidateCourseAndTeacherDuplicationAsync(dto.Name, dto.TeacherId);

            var course = new Course
            {
                Name = dto.Name,
                TeacherId = dto.TeacherId
            };
            await _repository.AddAsync(course);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<GetAllCourseDto>> GetAllAsync()
        => await _repository.GetAllAsync();

        private async Task EnsureTeacherExistAsync(int teacherId)
        {
            bool teacherExists = await _teacherRepository.TeacherExistAsync(teacherId);
            if  (!teacherExists)
                throw new IsNotExistTeacherException();
        }

        private async Task ValidateCourseAndTeacherDuplicationAsync(string courseName, int teacherId)
        {
            bool isDuplicate = await _repository.ValidateCourseAndTeacherDuplication(courseName, teacherId);
            if  (isDuplicate)
                throw new DuplicatedCourseAndTeacherException();
        }
    }
}
