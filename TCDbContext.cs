using Microsoft.EntityFrameworkCore;
using PaySky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaySky
{
    public class TCDbContext:DbContext
    {
        public TCDbContext(DbContextOptions options) : base(options)
        {

        }
       public DbSet<TransactionRequestModel> TransactionRequestModel { get; set; }
       public DbSet<UserModel> UserModel { get; set; }
        //public DbSet<TransactionResponseModel> TransactionResponseModel { get; set; }


    }
}
