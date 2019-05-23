using MonzoSankey.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using MonzoApi;

namespace MonzoSankey.Services.Transactions
{
    public class TransactionService : ITransactionService
    {
        public IEnumerable<Transaction> GetTransactions(MonzoClient client, DateTime? from = null, DateTime? to = null)
        {
            return client.GetTransactions(from, to);
        }
    }
}
