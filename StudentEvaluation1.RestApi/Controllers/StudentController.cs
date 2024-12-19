using Microsoft.AspNetCore.Mvc;
using StudentEvaluation1.Services.Courses.contracts.Dto;
using StudentEvaluation1.Services.Students.Contracts;
using StudentEvaluation1.Services.Students.Contracts.Dto;

namespace StudentEvaluation1.RestApi.Controllers
{
    [Route("students")]
    [ApiController]

    public class StudentController : Controller
    {
        private readonly StudentService _service;

        public StudentController(StudentService studentService)
        {
            _service = studentService;
        }

        [HttpPost]
        public async Task Add([FromBody] AddStudentDto dto)
        {
           await _service.AddAsync(dto);
        }

        [HttpGet]
        public async Task<List<GetAllStudentDto>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{StudentId}/teachers")]
        public async Task<List<GetTeacherDto>> GetTeachersById([FromRoute] int StudentId)
        {
            return await _service.GetTeachersByIdAsync(StudentId);
        }

        [HttpGet("{StudentId}/courses")]
        public List<GetCourseDto> GetCoursesById([FromRoute] int id)
        {
            return
                _service.GetCoursesById(id);
        }

        [HttpGet("{StudentId}/average")]
        public GetStudentAverageDto? GetStudentAverageById([FromRoute] int id)
        {
            return
                _service.GetStudentAverageById(id);
        }

        [HttpGet("order-by-average")]
        public List<GetStudentOrderByAverage> GetOrderByAverage()
        {
            return
                _service.GetOrderByAverage();
        }

        [HttpDelete("{StudentId}")]
        public void Delete([FromRoute] int id)
        {
            _service.DeleteById(id);
        }


    }
}
