using MeusicRuchama.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusicRuchama.Core.Serivecs
{
    public interface ILessonsServices
    {
        public Task<List<Lessons>> GetAllAsync();

        public void AddLessons(Lessons l);

        public Task UpdateLessonsAsync(Lessons l, int id);

        public Task DeleteLessonsAsync(int id);

        public Task<Lessons> GetByIdAsync(int id);

    }
}
