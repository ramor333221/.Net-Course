using MeusicRuchama.Core.Repositories;
using MeusicRuchama.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusicRuchama.Data.Repositories
{
    public class LessonRepositories: ILessonsRepositories
    {
        private readonly DataContext _context;
        public LessonRepositories(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Lessons>> GetAllAsync()
        {
            return await _context.lessons.ToListAsync();    
        }

        public void AddLessons(Lessons l)
        {
             _context.lessons.Add(l);
        }

        public async Task UpdateLessonsAsync(Lessons l,int id)
        {
            var lesson = await _context.lessons.FirstAsync(l => l.id == id);
            if (lesson != null)
            {
                lesson.teacherId = l.teacherId;
                lesson.name = l.name;
                lesson.day = l.day;
                lesson.start = l.start;
                lesson.end = l.end;
            }
        }

        public async Task DeleteLessonsAsync(int id)
        {
            var lesson =await _context.lessons.FirstAsync(l => l.id == id);
            if (lesson != null)
            {
               _context.lessons.Remove(lesson);
            }
        }

        public async Task<Lessons> GetByIdAsync(int id)
        {
            Lessons lesson = await _context.lessons.FirstAsync(t => t.id == id);
            if (lesson != null)
            {
                return lesson;
            }
            return null;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
