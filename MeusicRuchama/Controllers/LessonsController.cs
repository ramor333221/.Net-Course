using AutoMapper;
using MeusicRuchama.Core.DTOs;
using MeusicRuchama.Core.Serivecs;
using MeusicRuchama.Entities;
using MeusicRuchama.Models.Lesson;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeusicRuchama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonsServices _lessonService;
        private readonly IMapper _mapper;
        public LessonsController(ILessonsServices studentService, IMapper mapper)
        {
            _lessonService = studentService;
            _mapper = mapper;
        }

        // GET: api/<LessonsController>
        [HttpGet]
        public async Task<IEnumerable<LessonDTO>> Get()
        {
            var lessons = await _lessonService.GetAllAsync();
            return _mapper.Map<IEnumerable<LessonDTO>>(lessons);
        }


        // POST api/<LessonsController>
        [HttpPost]
        public Lessons Post([FromBody] LessonPostModel newL)
        {
            var lesson = _mapper.Map<Lessons>(newL);
            _lessonService.AddLessons(lesson);
            return lesson;
        }

        // PUT api/<LessonsController>/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] LessonPostModel update)
        {
            var lesson = await _lessonService.GetByIdAsync(id);
            if (lesson != null)
            {
                lesson.teacherId = update.teacherId;
                lesson.name = update.name;
                lesson.day = update.day;
                lesson.start = update.start;
                lesson.end = update.end;
            }
        }

        // DELETE api/<LessonsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var lesson = _lessonService.DeleteLessonsAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            _lessonService.DeleteLessonsAsync(id);
            return Ok();
        }
    }
}
