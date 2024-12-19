using Microsoft.AspNetCore.Mvc;
using StudentEvaluation1.Services.StudentCourses.Contracts;
using StudentEvaluation1.Services.StudentCourses.Contracts.Dto;

namespace StudentEvaluation1.RestApi.Controllers
{
    [Route("studentcourses")]
    [ApiController]

    public class StudentcourseController : Controller
    {
        private readonly StudentCourseService _servics;

        public StudentcourseController(StudentCourseService studentCourseService)
        {
            _servics = studentCourseService;
        }


        [HttpPost]
        public async Task Add([FromBody] AddStudentCourseDto dto)
        {
            await _servics.AddAsync(dto);
        }
    }
}
