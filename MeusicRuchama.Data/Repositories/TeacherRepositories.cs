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
    public class TeacherRepositories:ITechersRepositories
    {
        private readonly DataContext _context;
        public TeacherRepositories(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Teachers>> GetAllAsync()
        {
            return await _context.teachers.ToListAsync();
        }

        public async Task<Teachers> GetByIdAsync(int id)
        {
            var teacher =await _context.teachers.FirstAsync(t => t.id == id);
            if (teacher != null)
            {
                return teacher;
            }
            return null;
        }

        public void AddTeachers(Teachers t)
        {
            if (t != null)
            {
                _context.teachers.Add(t);
            }
        }

        public async Task UpdateTeachersAsync(Teachers t, int id)
        {
            var existingTeacher =await _context.teachers.FirstAsync(t => t.id == id);
            if (existingTeacher != null)
            {
                existingTeacher.name = t.name;
                existingTeacher.age = t.age;
                existingTeacher.phone = t.phone;
                existingTeacher.email = t.email;
            }
        }

        public async Task DeleteTeachersAsync(int id)
        {
            var teacher =await _context.teachers.FirstAsync(t => t.id == id);
            if (teacher != null)
            {
                _context.teachers.Remove(teacher);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
