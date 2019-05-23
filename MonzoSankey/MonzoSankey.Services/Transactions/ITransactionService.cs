using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MonzoApi;
using MonzoSankey.Core.Models;

namespace MonzoSankey.Services.Transactions
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetTransactions(MonzoClient client, DateTime? from = null, DateTime? to = null);
    }
}