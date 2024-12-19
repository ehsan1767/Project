using Microsoft.EntityFrameworkCore;
using StudentEvaluation1.Entites;
using StudentEvaluation1.Services.Teachers.Contracts;
using StudentEvaluation1.Services.Teachers.Contracts.Dto;

namespace StudentEvaluation1.Persistanse.EF.Teachers
{
    public class EFTeacherRepository : TeacherRepository
    {
        private readonly DbSet<Teacher> _teachers;
        private readonly DbSet<Course> _courses;
        private readonly DbSet<StudentCourse> _studentCourses;

        public EFTeacherRepository(EFDataContext context)
        {
            _teachers = context.Set<Teacher>();
            _courses = context.Set<Course>();
            _studentCourses = context.Set<StudentCourse>();
        }

        public async Task AddAsync(Teacher teacher)
        {
           await _teachers.AddAsync(teacher);
        }

        public List<GetAllTeacherDto> GetAll()
        {
            return
                _teachers.Select(_ => new GetAllTeacherDto
                {
                    Id = _.Id,
                    Name = _.Name,
                    Family = _.Family,
                    PersonnelCode = _.PersonnelCode,
                }).ToList();
        }
        public List<GetTeacherPerformanceDto> GetPerformanceById(int id)
        {
            return
                _courses.Where(_ => _.TeacherId == id)
                        .Select(_ => new GetTeacherPerformanceDto
                        {
                            CourseId = _.Id,
                            CourseName = _.Name,
                            StudentCount = _.StudentCourses.Count,
                            AverageScore = _.StudentCourses.Any()
                                           ? _.StudentCourses.Average(_ => _.Score)
                                           : 0m
                        }).ToList();
        }

        public async Task<bool> TeacherExistAsync(int TeacherId)
        {
            return await _teachers.AnyAsync(_ => _.Id == TeacherId);
        }

        public bool IsExistByPersonnelCode(string personnelCode)
        {
            return
                _teachers.Any(_ => _.PersonnelCode == personnelCode);
        }

    }
}
