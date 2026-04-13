using MeusicRuchama.Core.Repositories;
using MeusicRuchama.Core.Serivecs;
using MeusicRuchama.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusicRuchama.Service
{
    public class StudentService : IStudentServices
    {
        private readonly IStudentRepositories _studentRepository;

        public StudentService(IStudentRepositories studentsRepository)
        {
            _studentRepository = studentsRepository;
        }


        public async Task<List<Students>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Students> GetByIdAsync(int id)
        {
            var slot = await _studentRepository.GetByIdAsync(id);
            if (slot == null)
            {
                return null;
            }
            return slot;
        }


        public async Task AddStudentAsync(Students l)
        {
            await _studentRepository.AddStudentAsync(l);
            await _studentRepository.SaveAsync();
        }

        public async Task UpdateStudent(Students s, int id)
        {
            await _studentRepository.UpdateStudentAsync(s,id);
            await _studentRepository.SaveAsync();
        }

        public async Task DeleteStudent(int id)
        {
            var slot = await _studentRepository.GetByIdAsync(id);
            if (slot != null)
            {
                await _studentRepository.DeleteStudentAsync(slot.id);
            }
            await _studentRepository.SaveAsync();
        }
    }
}
