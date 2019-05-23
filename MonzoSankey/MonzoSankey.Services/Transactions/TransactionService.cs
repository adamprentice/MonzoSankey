using MonzoSankey.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using MonzoApi;
using MonzoSankey.Services.Models;

namespace MonzoSankey.Services.Transactions
{
    public class TransactionService : ITransactionService
    {
        public SankeyResponse GetSankeyDataForTransactions(MonzoClient client, DateTime? from = null, DateTime? to = null)
        {
            var transactions = client.GetTransactions(from, to);

            var income = transactions.Where(x => x.Amount > 0);
            var outgoings = transactions.Where(x => x.Amount < 0);
            var categories = outgoings.Select(x => x.Category).Distinct();
            var merchants = outgoings.Where(x => x.Merchant != null).Select(x => x.Merchant).Distinct();
            var unknown = outgoings.Where(x => x.Merchant == null);

            var nodes = new List<SankeyNode>();
            nodes.Add(new SankeyNode("Income"));
            nodes.Add(new SankeyNode("Transfer"));

            nodes.AddRange(categories.Select(x => new SankeyNode(x)));
            nodes.AddRange(merchants.Select(x => new SankeyNode(x.Name)));

            var links = new List<SankeyLink>();

            links.AddRange(categories.Select(category => new SankeyLink(0, nodes.FindIndex(x => x.Name == category), outgoings.Where(x => x.Category == category).Select(x => Math.Abs(x.Amount) / 100).Sum())));
            links.AddRange(outgoings.Where(x => x.Merchant == null).Select(outgoing => new SankeyLink(nodes.FindIndex(x => x.Name == outgoing.Category), 1, Math.Abs(outgoing.Amount) / 100)));

            // There has to be a better way of doing this...
            foreach (var merchant in merchants)
            {
                // This could be one line but it would be hideous
                var outgoingsAtMerchant = outgoings.Where(x => x.Merchant == merchant).GroupBy(x => x.Category);
                var merchantNode = nodes.FindIndex(x => x.Name == merchant.Name);

                links.AddRange(outgoingsAtMerchant.Select(category => new SankeyLink(nodes.FindIndex(node => node.Name == category.Key), merchantNode, category.Sum(outgoing => Math.Abs(outgoing.Amount) / 100))));
            }

            return new SankeyResponse(nodes, links);
        }
    }
}
