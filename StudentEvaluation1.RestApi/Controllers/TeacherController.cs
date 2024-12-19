using Microsoft.AspNetCore.Mvc;
using StudentEvaluation1.Services.Teachers.Contracts;
using StudentEvaluation1.Services.Teachers.Contracts.Dto;

namespace StudentEvaluation1.RestApi.Controllers
{
    [Route("teachers")]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly TeacherService _service;

        public TeacherController(TeacherService teacherService)
        {
            _service = teacherService;
        }

        [HttpPost]
        public void Add([FromBody] AddTeacherDto dto)
        {
            _service.Add(dto);
        }

        [HttpGet]
        public List<GetAllTeacherDto> GetAll()
        {
            return
                _service.GetAll();
        }

        [HttpGet("{id}/performance")]
        public List<GetTeacherPerformanceDto> GetPerformanceById([FromRoute] int id)
        {
            return
                _service.GetPerformanceById(id);
        }

    }
}
