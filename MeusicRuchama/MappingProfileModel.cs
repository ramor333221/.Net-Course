using AutoMapper;
using MeusicRuchama.Core.DTOs;
using MeusicRuchama.Entities;
using MeusicRuchama.Models.Lesson;
using MeusicRuchama.Models.Student;
using MeusicRuchama.Models.Teacher;

namespace MeusicRuchama
{
    
    public class MappingProfileModel : Profile
    {
        public MappingProfileModel()
        {
            CreateMap<LessonPostModel, Lessons>().ReverseMap();
            CreateMap<StudentPostModel, Students>().ReverseMap();
            CreateMap<TeacherPostModel, Teachers>().ReverseMap();
        }
    }

}
