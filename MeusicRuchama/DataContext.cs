using MeusicRuchama.Entities;

namespace MeusicRuchama.Data
{
    public class DataContext
    {
        public List<Students> students { get; set; }
        public List<Teachers> teachers { get; set; }
        public List<Lessons> lessons { get; set; }
        public DataContext()
        {
            lessons = new List<Lessons> { new Lessons { id = 1, teacherId = 1, name = "organ", day = 1, start = new TimeOnly(4, 30), end = new TimeOnly(5, 30) } };
            teachers = new List<Teachers> { new Teachers { id = 1, name = "hgf", age = 12, phone = "76976976", email = "fjh@dt" } };
            students = new List<Students> { new Students { id = 1, name = "hgf", age = 12, phone = "76976976", email = "fjh@dt" } };
        }
    }
}

