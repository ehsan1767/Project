using Microsoft.EntityFrameworkCore;
using StudentEvaluation1.Entites;
using StudentEvaluation1.Services.Courses.contracts.Dto;
using StudentEvaluation1.Services.Students.Contracts;
using StudentEvaluation1.Services.Students.Contracts.Dto;

namespace StudentEvaluation1.Persistanse.EF.Students
{
    public class EFStudentRepository : StudentRepository
    {
        private readonly DbSet<Student> _students;
        private readonly DbSet<StudentCourse> _studentCourse;

        public EFStudentRepository(EFDataContext context)
        {
            _students = context.Set<Student>();
            _studentCourse = context.Set<StudentCourse>();
        }

        public async Task AddAsync(Student student)
        {
            await _students.AddAsync(student);
        }
        public void Delete(Student student)
        {
            _students.Remove(student);
        }

        public async Task<List<GetAllStudentDto>> GetAll()
        {
            return
                  await _students.Select(_ => new GetAllStudentDto
                  {
                      Id = _.Id,
                      Name = _.Name,
                      Family = _.Family,
                      NationalCode = _.NationalCode,

                  }).ToListAsync();
        }
        public List<GetCourseDto> GetCoursesById(int id)
        {
            return
                  _studentCourse.Where(_ => _.StudentId == id)
                                .Select(_ => new GetCourseDto
                                {
                                    Id = _.CourseId,
                                    Name = _.Course.Name
                                })
                                  .Distinct()
                                  .ToList();
        }

        public async Task<List<GetTeacherDto>> GetTeachersByIdAsync(int studentId)
        {
            return await _studentCourse
               .AsNoTracking()
               .Where(_ => _.StudentId == studentId)
               .Select(_ => _.Course.Teacher)
               .Select(t => new GetTeacherDto
               {
                   TeacherId = t.Id,
                   Name = t.Name,
                   Family = t.Family,
                   PersonnelCode = t.PersonnelCode,

               }).ToListAsync();
        }

        public GetStudentAverageDto? GetStudentAverageById(int id)
        {
            return
                _students.Where(_ => _.Id == id)
                         .Select(_ => new GetStudentAverageDto
                         {
                             Name = _.Name,
                             Family = _.Family,
                             NationalCode = _.NationalCode,

                             AverageStudent = _.StudentCourses.Any()
                                             ? _.StudentCourses.Average(sc => sc.Score)
                                             : 0m

                         }).FirstOrDefault();
        }
        public List<GetStudentOrderByAverage> GetOrderByAverage()
        {
            return
                _students.Select(_ => new GetStudentOrderByAverage
                {
                    Id = _.Id,
                    Name = _.Name,
                    Family = _.Family,
                    NationalCode = _.NationalCode,

                    StudentAverage = _.StudentCourses.Any()
                                   ? _.StudentCourses.Average(_ => _.Score)
                                   : 0m
                })
                 .OrderByDescending(_ => _.StudentAverage)
                 .ToList();
        }

        public bool IsDuplicatedNationalCode(string nationalCode)
        {
            return
                 _students.Any(_ => _.NationalCode == nationalCode);
        }

        public async Task<bool> StudentExistAsync(int id)
        {
            return await _students.AnyAsync(_ => _.Id == id);
        }

        public Student? FindById(int id)
        {
            return
                _students.FirstOrDefault(s => s.Id == id);
        }
       
    }
}
