using MeusicRuchama.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusicRuchama.Core.Repositories
{
    public interface IUserRepository
    {
        public Task<Users> GetByUserNameAsync(string UserName, string Password);
        public Task<Users> AddUserAsync(Users user);
    }
}

