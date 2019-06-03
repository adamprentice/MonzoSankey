using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MonzoApi;
using MonzoApi.Services;
using MonzoSankey.Core.Models;
using MonzoSankey.Services.Models;

namespace MonzoSankey.Services.Transactions
{
    public interface ITransactionService
    {
        SankeyResponse GetSankeyDataForTransactions(List<Transaction> transactions);
    }
}