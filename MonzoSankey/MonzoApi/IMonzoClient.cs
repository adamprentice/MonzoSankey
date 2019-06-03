using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MonzoSankey.Core.Models;

namespace MonzoApi.Services
{
    public interface IMonzoClient : IDisposable
    {
        Task<List<Transaction>> GetTransactions(string[] accountIds, DateTime? from = null, DateTime? to = null);
    }
}