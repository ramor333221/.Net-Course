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
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Users> GetByUserNameAsync(string userName, string Password)
        {
            return await _dataContext.users.FirstAsync(u => u.UserName == userName && u.Password == Password);
        }

        public async Task<Users> AddUserAsync(Users user)
        {
            await _dataContext.users.AddAsync(user);
            return user;
        }
    }

}
