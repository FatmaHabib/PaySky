using PaySky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaySky.IRepository
{
   public interface ITransactionRepository
    {
        Task<int> SaveTransaction(TransactionRequestModel reqest);

    }
}
