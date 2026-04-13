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
    public class TeachersService: ITeachersServies
    {
        private readonly ITechersRepositories _teacherRepository;

        public TeachersService(ITechersRepositories teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }


        public async Task<List<Teachers>> GetAllAsync()
        {
            return await _teacherRepository.GetAllAsync();
        }

        public async Task<Teachers> GetByIdAsync(int id)
        {
            var teacher =await _teacherRepository.GetByIdAsync(id);
            if (teacher == null)
            {
                return null;
            }
            return teacher;
        }


        public async Task AddTeacherAsync(Teachers t)
        {
            await _teacherRepository.AddTeacherAsync(t);
            await _teacherRepository.SaveAsync();
        }

        public async Task UpdateTeachersAsync(Teachers t, int id)
        {
            await _teacherRepository.UpdateTeachersAsync(t,id);
            await _teacherRepository.SaveAsync();
        }

        public async Task DeleteTeachersAsync(int id)
        {
            await _teacherRepository.DeleteTeachersAsync(id);
           await _teacherRepository.SaveAsync();
        }
    }
}
