using Microsoft.AspNetCore.Mvc;
using StudentEvaluation1.Services.Courses.contracts;
using StudentEvaluation1.Services.Courses.contracts.Dto;

namespace StudentEvaluation1.RestApi.Controllers
{
    [Route("courses")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly CourseService _service;
        public CourseController(CourseService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task Add([FromBody] AddCourseDto dto)
        {
            await _service.AddCourseAsync(dto);
        }

        [HttpGet]

        public async Task<List<GetAllCourseDto>> GetAll()
        {
            return await _service.GetAllAsync();
        }

    }
}
