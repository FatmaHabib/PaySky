using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaySky.IRepository;
using PaySky.Models;

namespace PaySky.Repository
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(TCDbContext dataContextFactory) : base(dataContextFactory)
        {

        }
        public async Task<UserModel> GetUser(UserModel user)
        {
            UserModel result = await _context.UserModel.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefaultAsync();
            return result;
        }

    }
}
