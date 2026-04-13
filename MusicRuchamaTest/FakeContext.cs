//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MeusicRuchama.Entities;
//using MeusicRuchama;

//namespace MusicRuchamaTest
//{
//    public class FakeContext : IDataContext
//    {
//        public List<Students> students { get; set; }
//        public List<Teachers> teachers { get; set; }
//        public List<Slots> slots { get; set; }
//        public List<Lessons> lessons { get; set; }
//        public FakeContext()
//        {
//            slots = new List<Slots> { new Slots { idSlot = 2, studentId = 2, lessonId = 2 } };
//            lessons = new List<Lessons> { new Lessons { id = 3, teacherId = 3, name = "dd", day = 4, start = new TimeOnly(4, 30), end = new TimeOnly(5, 30) } };
//            teachers = new List<Teachers> { new Teachers { id = 5, name = "hh", age = 12, phone = "76976976", email = "fjh@dt" } };
//            students = new List<Students> { new Students { id = 6, name = "lll", age = 12, phone = "76976976", email = "fjh@dt" } };
//        }
//    }
//}
