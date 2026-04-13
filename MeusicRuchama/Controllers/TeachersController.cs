using AutoMapper;
using MeusicRuchama.Core.DTOs;
using MeusicRuchama.Core.Serivecs;
using MeusicRuchama.Entities;
using MeusicRuchama.Models.Teacher;
using MeusicRuchama.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeusicRuchama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "teacher")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeachersServies _teacherService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public TeachersController(IUserService userService,ITeachersServies teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
            _userService = userService;
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
        public async Task<ActionResult> Post([FromBody] TeacherPostModel t)
        {
            var user = new Users { UserName = t.UserName, Password = t.Password, Role = eRole.teacher };
            var User = await _userService.AddUserAsync(user);
            var student = _mapper.Map<Teachers>(t);
            student.User = User;
            student.UserId = User.Id;
            _teacherService.AddTeacherAsync(student);
            return Ok(t);
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
