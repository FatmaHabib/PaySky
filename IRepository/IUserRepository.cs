using PaySky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaySky.IRepository
{
    public interface IUserRepository
    {
        Task<UserModel> GetUser(UserModel user);

    }
}
