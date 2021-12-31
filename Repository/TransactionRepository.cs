using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaySky.IRepository;
using PaySky.Models;

namespace PaySky.Repository
{
    public class TransactionRepository : RepositoryBase, ITransactionRepository
    {
        public TransactionRepository(TCDbContext dataContextFactory) : base(dataContextFactory)
        {

        }
       public async Task<int> SaveTransaction(TransactionRequestModel reqest)
        {
            _context.TransactionRequestModel.Add(reqest);
           return await _context.SaveChangesAsync();
        }

    }
}
