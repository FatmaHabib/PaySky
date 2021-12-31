using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PaySky
{
    public class RepositoryBase 
    {
        public  TCDbContext _context;

        public RepositoryBase(TCDbContext dbConnection)
        {
            _context = dbConnection;
        }
    }
}
