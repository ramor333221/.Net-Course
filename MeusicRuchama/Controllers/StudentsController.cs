using AutoMapper;
using MeusicRuchama;
using MeusicRuchama.Core.DTOs;
using MeusicRuchama.Core.Serivecs;
using MeusicRuchama.Entities;
using MeusicRuchama.Models.Student;
using MeusicRuchama.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicRuchama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "student")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentServices _studentService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public StudentsController(IStudentServices studentService, IMapper mapper,IUserService userService)
        {
            _studentService = studentService;
            _mapper = mapper;
            _userService = userService;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public async Task<List<StudentDTO>> Get()
        {
            var students = await _studentService.GetAllAsync();
            return _mapper.Map<List<StudentDTO>>(students);
        }
        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public Task<Students> Get(int id)
        {
            var student = _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return null;
            }
            return student;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StudentPostModel s)
        {
            var user = new Users { UserName = s.UserName, Password = s.Password, Role = eRole.student };
            var User = await _userService.AddUserAsync(user); 
            var student = _mapper.Map<Students>(s);
            student.User = User;
            student.UserId = User.Id;
            _studentService.AddStudentAsync(student);
            return Ok(s);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] StudentPostModel s)
        {
            var student =await  _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            student.name = s.name;
            student.age = s.age;
            student.phone = s.phone;
            student.email = s.email;
            return Ok();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student1 = _studentService.GetByIdAsync(id);
            if (student1 == null)
            {
                return NotFound();
            }
            _studentService.DeleteStudent(id);
            return Ok();
        }

    }
}
