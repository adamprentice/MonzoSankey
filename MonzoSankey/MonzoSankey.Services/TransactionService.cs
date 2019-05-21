using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mondo;
using MonzoSankey.Services.Models;

namespace MonzoSankey.Services
{
    public class TransactionService : ITransactionService
    {
        private IMondoClient client => MonzoClient.Client; // Neaten it up a little

        public TransactionService()
        {

        }

        public async Task<List<Models.Transaction>> GetTransactions(DateTime from, DateTime to)
        {
            var accounts = await this.client.GetAccountsAsync(); // TODO: get the accounts when the user logs in and store them in cache

            var transactions = new List<Models.Transaction>();

            var paginationOptions = new PaginationOptions()
            {
                SinceTime = from,
                BeforeTime = to
            };

            foreach (var account in accounts) // TODO: after remaking the client, this only needs to get the currently open ones.
            {
                var accountTransactions = await this.client.GetTransactionsAsync(account.Id, "merchant", paginationOptions);

                transactions.AddRange(accountTransactions.Select(trn => new Models.Transaction(trn)));
            }

            return transactions;
        }
    }
}
