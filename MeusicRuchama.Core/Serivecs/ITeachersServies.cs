using MeusicRuchama.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusicRuchama.Core.Serivecs
{
    public interface ITeachersServies
    {
        public Task<List<Teachers>> GetAllAsync();

        public Task<Teachers> GetByIdAsync(int id);

        public void AddTeachers(Teachers t);

        public Task UpdateTeachersAsync(Teachers t, int id);

        public Task DeleteTeachersAsync(int id);
    }
}
