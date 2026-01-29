using MeusicRuchama.Core.Repositories;
using MeusicRuchama.Core.Serivecs;
using MeusicRuchama.Entities;
using MeusicRuchama.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MeusicRuchama.Service
{
    public class LessonService: ILessonsServices
    {

        private readonly ILessonsRepositories _lessonRepository;

        public LessonService(ILessonsRepositories lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<List<Lessons>> GetAllAsync()
        {
            return await _lessonRepository.GetAllAsync();
        }

        public async Task<Lessons> GetByIdAsync(int id)
        {
            var lessons = await _lessonRepository.GetByIdAsync(id);
            if (lessons == null)
            {
                return null;
            }
            return lessons;
        }

        public void AddLessons(Lessons l)
        {
            _lessonRepository.AddLessons(l);
            _lessonRepository.SaveAsync();
        }

        public async Task UpdateLessonsAsync(Lessons l, int id)
        {
          await _lessonRepository.UpdateLessonsAsync(l,id);
            await _lessonRepository.SaveAsync();
        }

        public async Task DeleteLessonsAsync(int id)
        {
            if (id != null)
            {
               await _lessonRepository.DeleteLessonsAsync(id);
            }
            await _lessonRepository.SaveAsync();
        }
    }
}
