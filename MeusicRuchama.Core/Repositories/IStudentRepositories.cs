using MeusicRuchama.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusicRuchama.Core.Repositories
{
    public interface IStudentRepositories
    {
        public Task<List<Students>> GetAllAsync();

        public Task<Students> GetByIdAsync(int id);

        public Task AddStudentAsync(Students s);

        public Task UpdateStudentAsync(Students s, int id);

        public Task DeleteStudentAsync(int id);

        public Task SaveAsync();
    }
}
