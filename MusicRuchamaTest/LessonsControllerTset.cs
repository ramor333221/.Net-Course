//using MeusicRuchama.Controllers;
//using MeusicRuchama.Entities;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using Xunit;


//namespace MusicRuchamaTest
//{
//    public class LessonsControllerTset
//    {
//        private FakeContext fakeContext = new FakeContext();
//        [Fact]
//        public void Get_ReturnList()
//        {
//            var controller=new LessonsController(fakeContext);
//            var result = controller.Get();

//            Assert.IsType<List<Lessons>>(result);
//        }

//        [Fact]
//        public void Post_addLesson()
//        {
//            Lessons l = new Lessons { id = 2, teacherId = 1, name = "qq", day = 1, start = new TimeOnly(5, 30), end = new TimeOnly(6, 30), };
//            var controller=new LessonsController(fakeContext);
//            var result = controller.Post(l);

//            Assert.IsType<Lessons>(result);
//        }

//        [Fact]
//        public void Put_updateLesson()
//        {
//            Lessons l = new Lessons { id =1, teacherId = 1, name = "nnnnnnn", day = 1, start = new TimeOnly(5, 40), end = new TimeOnly(6, 30), };
//            var controller = new LessonsController(fakeContext);
//            var result = controller.Put(1,l);

//            Assert.IsType<Lessons>(result);
//        }

//        [Fact]
//        public void Delete_deleteLesson()
//        {
//            var controller = new LessonsController(fakeContext);
//            var result = controller.Delete(1);

//            Assert.IsType<OkResult>(result);
//        }
//    }
//}