using AutoMapper;
using MeusicRuchama.Core.DTOs;
using MeusicRuchama.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusicRuchama.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Students, StudentDTO>().ReverseMap();
            CreateMap<Teachers, TeacherDTO>().ReverseMap();
            CreateMap<Lessons, LessonDTO>().ReverseMap();

        }
    }
}
