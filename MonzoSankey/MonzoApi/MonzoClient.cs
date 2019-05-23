using MonzoSankey.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MonzoApi
{
    public class MonzoClient
    {
        private List<Transaction> transactions;

        public MonzoClient()
        {
            this.transactions = JsonConvert.DeserializeObject<List<Transaction>>(File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),"Data/transactions.json")));
        }

        public IEnumerable<Transaction> GetTransactions(DateTime? from = null, DateTime? to = null)
        {
            return this.transactions.Where(x => (from == null || x.Settled > from) && (to == null || x.Settled < to));
        }
    }
}
