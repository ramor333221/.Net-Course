using AutoMapper;
using MeusicRuchama.Core.DTOs;
using MeusicRuchama.Core.Serivecs;
using MeusicRuchama.Entities;
using MeusicRuchama.Models.Teacher;
using MeusicRuchama.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeusicRuchama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeachersServies _teacherService;
        private readonly IMapper _mapper;
        public TeachersController(ITeachersServies teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        // GET: api/<TeachersController>
        [HttpGet]
        public async Task<List<TeacherDTO>> Get()
        {
            var teachers = await _teacherService.GetAllAsync();
            return _mapper.Map<List<TeacherDTO>>(teachers);
        }

        // GET api/<TeachersController>/5
        [HttpGet("{id}")]
        public ActionResult<TeacherDTO> Get(int id)
        {
            var teacher = _teacherService.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        // POST api/<TeachersController>
        [HttpPost]
        public ActionResult Post([FromBody] TeacherPostModel t)
        {
            var teacher = _mapper.Map<Teachers>(t);
            if (teacher == null)
            {
                return BadRequest();
            }
            _teacherService.AddTeachers(teacher);
            return Ok();
        }

        // PUT api/<TeachersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TeacherPostModel teacher)
        {
            if (teacher == null || id != teacher.id)
            {
                return BadRequest();
            }

            var existingTeacher =await _teacherService.GetByIdAsync(id);
            if (existingTeacher == null)
            {
                return NotFound();
            }

            existingTeacher.name = teacher.name;
            existingTeacher.age = teacher.age;
            existingTeacher.phone = teacher.phone;
            existingTeacher.email = teacher.email;

            return NoContent();
        }

        // DELETE api/<TeachersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var teacher =await _teacherService.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _teacherService.DeleteTeachersAsync(id);
            return NoContent();
        }
    }
}
