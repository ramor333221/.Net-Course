//using MeusicRuchama.Controllers;
//using MeusicRuchama.Entities;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MusicRuchamaTest
//{
//    public class TeachersControllerTests
//    {
//        private FakeContext fakeContext = new FakeContext();
//        [Fact]
//        public void Get_ReturnsAllTeachers()
//        {
//            var controller = new TeachersController(fakeContext);
//            var result = controller.Get();
//            Assert.IsType<List<Teachers>>(result);
//        }

//        [Fact]
//        public void Get_ReturnsTeacherById()
//        {
//            var controller = new TeachersController(fakeContext);
//            int teacherId = 7;
//            var result = controller.Get(teacherId);
//            Assert.IsType<ActionResult<Teachers>>(result);
//        }

      
//        [Fact]
//        public void Post_AddTeacher()
//        {
//            var newTeacher = new Teachers { id = 8, name = "new teacher", age = 30, phone = "123456789", email = "new@teacher.com" };
//            var controller = new TeachersController(fakeContext);
//            var result = controller.Post(newTeacher);
//            Assert.IsType<OkResult>(result);
//        }

//        [Fact]
//        public void Put_UpdateTeacher()
//        {
//            var updatedTeacher = new Teachers { id = 7, name = "updated name", age = 35, phone = "987654321", email = "updated@teacher.com" };
//            var controller = new TeachersController(fakeContext);
//            var result = controller.Put(7, updatedTeacher);
//            Assert.IsType<NoContentResult>(result);
//        }

//        [Fact]
//        public void Delete_DeleteTeacher()
//        {
//            var controller = new TeachersController(fakeContext);
//            var result = controller.Delete(7);
//            Assert.IsType<NoContentResult>(result);
//        }

       
//    }
//}
