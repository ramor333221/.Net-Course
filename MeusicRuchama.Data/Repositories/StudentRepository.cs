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
    public class StudentRepository: IStudentRepositories
    {
        private readonly DataContext _context;
        public StudentRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Students>> GetAllAsync()
        {
           return await _context.students.ToListAsync();
        }

        public async Task<Students> GetByIdAsync(int id)
        {
            var s =await _context.students.FirstAsync(s => s.id == id);
            if (s == null)
            {
                return null;
            }
            return s;
        }

        public async Task AddStudentAsync(Students s)
        {
            var st = await _context.students.FirstAsync(s1 => s1.id == s1.id);
            if (st == null)
            {
               _context.students.Add(s);
            }
        }

        public async Task UpdateStudentAsync(Students s, int id)
        {
            var student =await _context.students.FirstAsync(l => l.id == id);
            if (student != null)
            {
                student.name = s.name;
                student.age = s.age;
                student.phone = s.phone;
                student.email = s.email;
            }
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student1 =await _context.students.FirstAsync(l => l.id == id);
            if (student1 != null)
            {
               _context.students.Remove(student1);
            }
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
