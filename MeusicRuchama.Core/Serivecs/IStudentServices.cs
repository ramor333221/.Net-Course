using MeusicRuchama.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusicRuchama.Core.Serivecs
{
    public interface IStudentServices
    {
        public Task<List<Students>> GetAllAsync();

        public Task<Students> GetByIdAsync(int id);

        public Task AddStudentAsync(Students s);

        public Task UpdateStudent(Students s, int id);

        public Task DeleteStudent(int id);
    }
}
