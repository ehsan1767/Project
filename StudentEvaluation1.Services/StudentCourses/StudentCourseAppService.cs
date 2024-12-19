using StudentEvaluation1.Entites;
using StudentEvaluation1.Services.Contracts;
using StudentEvaluation1.Services.Courses.contracts;
using StudentEvaluation1.Services.Courses.Exceptions;
using StudentEvaluation1.Services.StudentCourses.Contracts;
using StudentEvaluation1.Services.StudentCourses.Contracts.Dto;
using StudentEvaluation1.Services.StudentCourses.Exceptions;
using StudentEvaluation1.Services.Students.Contracts;
using StudentEvaluation1.Services.Students.Excentions;

namespace StudentEvaluation1.Services.StudentCourses
{
    public class StudentCourseAppService : StudentCourseService
    {
        private readonly StudentCourseRepository _repository;
        private readonly StudentRepository _studentRepository;
        private readonly CourseRepository _courseRepository;
        private readonly UnitOfWork _unitOfWork;

        public StudentCourseAppService(
            StudentCourseRepository studentCourseRepository,
            StudentRepository studentRepository,
            CourseRepository courseRepository,
            UnitOfWork unitOfWork)
        {
            _repository = studentCourseRepository;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(AddStudentCourseDto dto)
        {
            ValidateTestDate(dto.TestDate);
            ValidateScore(dto.Score);
            await ValidateStudentExistence(dto.StudentId);
            await EnsureCourseExistAsync(dto.CourseId);
            await IsDuplicatedStudentAndCourse(dto.StudentId, dto.CourseId);
            await ValidateDuplicateStudenAndCourseAndTestDate(dto.StudentId, dto.CourseId, dto.TestDate);

            var studentCourse = new StudentCourse
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId,
                Score = dto.Score,
                TestDate = dto.TestDate
            };

            await _repository.AddAsync(studentCourse);
            await _unitOfWork.SaveAsync();
        }

        //Validate StudentExistAsync Exist
        private async Task ValidateStudentExistence(int studentId)
        {
            if (!await IsStudentExistAsync(studentId))
                throw new StudentNotExistException();
        }
        private async Task<bool> IsStudentExistAsync(int studentId)
        {
            return await _studentRepository.StudentExistAsync(studentId);
        }

        //
        private async Task EnsureCourseExistAsync(int courseId)
        {
            if (!await IscourseExistAsync(courseId))
                throw new CourseNotExistException();
        }
        private async Task<bool> IscourseExistAsync(int courseId)
        {
            return await _courseRepository.CourseExistsAsync(courseId);
        }

        //validate Score
        private void ValidateScore(decimal score)
        {
            const decimal minScore = 0;
            const decimal maxScore = 20;

            if (!IsScoreValid(score, minScore, maxScore))
                throw new InvalidScoreException();
        }
        private bool IsScoreValid(decimal score, decimal min, decimal max)
        {
            return score >= min && score <= max;
        }

        //Validate TestDate
        private void ValidateTestDate(DateTime testData)
        {
            if (IsTestDateValid(testData))
                throw new InvalidTestDateException();
        }
        private bool IsTestDateValid(DateTime testDate)
        {
            return testDate < DateTime.Now;
        }

        //Duplicated StudentExistAsync And Course
        private async Task IsDuplicatedStudentAndCourse(int studentId, int courseId)
        {
            if (await IsStudentAndCourseDuplicatedAsync(studentId, courseId))
                throw new IsDuplicatedStudentAndCourseException();
        }
        private async Task<bool> IsStudentAndCourseDuplicatedAsync(int studentId, int courseId)
        {
            return await _repository.IsDuplicatedStudentAndCourseAsync(studentId, courseId);
        }

        //Validate StudentExistAsync And Course And TestDate DuplicatedB
        private async Task ValidateDuplicateStudenAndCourseAndTestDate(int studentId, int courseId, DateTime testDate)
        {
            if (await IsStudentandCourseAndTestDateDuplicated(studentId, courseId, testDate))
            {
                throw new IsDuplicatedTestDateException();
            }
        }
        private async Task<bool> IsStudentandCourseAndTestDateDuplicated(int studentId, int courseId, DateTime testDate)
        {
            return await _repository.IsDuplicatedStudentandCourseAndTestDateAsync(studentId, courseId, testDate);
        }
    }
}
