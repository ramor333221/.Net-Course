using System.ComponentModel.DataAnnotations;

namespace MeusicRuchama.Entities
{
    public class Lessons
    {
        [Key]

        public int id { get; set; }
        public int teacherId { get; set; }
        public string name { get; set; }
        public int day { get; set; }
        public TimeOnly start { get; set; }
        public TimeOnly end { get; set; }

        public List<Students> students { get; set; }

        public Teachers teachers { get; set; }

    }
}
