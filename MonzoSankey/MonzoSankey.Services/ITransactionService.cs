using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MonzoSankey.Services.Models;

namespace MonzoSankey.Services
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetTransactions(DateTime from, DateTime to);
    }
}