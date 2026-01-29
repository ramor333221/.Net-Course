//using MeusicRuchama.Controllers;
//using MeusicRuchama.Entities;
//using Microsoft.AspNetCore.Mvc;
//using MusicRuchama.Controllers;
//using System.Collections.Generic;
//using Xunit;

//namespace MusicRuchamaTest
//{
//    public class StudentsControllerTests
//    {
//        private FakeContext fakeContext = new FakeContext();
//        [Fact]
//        public void Get_ReturnsAllStudents()
//        {
//            var controller = new StudentsController(fakeContext);
//            var result = controller.Get();
//            Assert.IsType<List<Students>>(result);
//        }

//        [Fact]
//        public void Get_ReturnsStudentById()
//        {
//            var controller = new StudentsController(fakeContext);
//            int studentId = 7;
//            var result = controller.Get(studentId);
//            Assert.IsType<Students>(result);
//        }

//        [Fact]
//        public void Post_AddStudent()
//        {
//            var newStudent = new Students { id = 8, name = "new student", age = 15, phone = "123456789", email = "new@student.com" };
//            var controller = new StudentsController(fakeContext);
//            var result = controller.Post(newStudent);
//            var okResult = Assert.IsType<OkObjectResult>(result);
//            var addedStudent = Assert.IsType<Students>(okResult.Value);
//            Assert.Equal(newStudent.id, addedStudent.id);
//        }

//        [Fact]
//        public void Post_ReturnsConflict_WhenStudentExists()
//        {
//            var existingStudent = new Students { id = 7, name = "hgf", age = 12, phone = "76976976", email = "fjh@dt" };
//            var controller = new StudentsController(fakeContext);
//            var result = controller.Post(existingStudent);
//            Assert.IsType<ConflictResult>(result);
//        }

//        [Fact]
//        public void Put_UpdateStudent()
//        {
//            var updatedStudent = new Students { id = 7, name = "updated name", age = 13, phone = "987654321", email = "updated@student.com" };
//            var controller = new StudentsController(fakeContext);
//            var result = controller.Put(7, updatedStudent);
//            Assert.IsType<OkResult>(result);
//        }


//        [Fact]
//        public void Delete_DeleteStudent()
//        {
//            var controller = new StudentsController(fakeContext);
//            var result = controller.Delete(7);
//            Assert.IsType<OkResult>(result);
//        }

//    }
//}