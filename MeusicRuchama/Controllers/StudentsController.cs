using AutoMapper;
using MeusicRuchama;
using MeusicRuchama.Core.DTOs;
using MeusicRuchama.Core.Serivecs;
using MeusicRuchama.Entities;
using MeusicRuchama.Models.Student;
using MeusicRuchama.Service;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicRuchama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentServices _studentService;
        private readonly IMapper _mapper;
        public StudentsController(IStudentServices studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
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
        public IActionResult Post([FromBody] StudentPostModel s)
        {
            var student = _mapper.Map<Students>(s);
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
