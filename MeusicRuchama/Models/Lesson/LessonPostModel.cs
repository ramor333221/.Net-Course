using MeusicRuchama.Entities;

namespace MeusicRuchama.Models.Lesson
{
    public class LessonPostModel
    {
        public int teacherId { get; set; }
        public string name { get; set; }
        public int day { get; set; }
        public TimeOnly start { get; set; }
        public TimeOnly end { get; set; }
        public Teachers teachers { get; set; }
    }
}
