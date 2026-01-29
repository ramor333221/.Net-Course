using System.ComponentModel.DataAnnotations;

namespace MeusicRuchama.Entities
{
    public class Teachers
    {

        [Key]

        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        public List<Lessons> lessons { get; set; }
    }
}
