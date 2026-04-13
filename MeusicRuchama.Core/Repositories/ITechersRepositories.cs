using MeusicRuchama.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusicRuchama.Core.Repositories
{
    public interface ITechersRepositories
    {
        public Task<List<Teachers>> GetAllAsync();

        public Task<Teachers> GetByIdAsync(int id);

        public Task AddTeacherAsync(Teachers t);

        public Task UpdateTeachersAsync(Teachers t, int id);

        public Task DeleteTeachersAsync(int id);

        public Task SaveAsync();
    }
}
