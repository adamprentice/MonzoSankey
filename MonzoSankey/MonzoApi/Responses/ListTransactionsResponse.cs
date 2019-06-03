using MonzoSankey.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonzoApi.Services.Responses
{
    public class ListTransactionsResponse
    {
        public List<Transaction> Transactions { get; set; }
    }
}
