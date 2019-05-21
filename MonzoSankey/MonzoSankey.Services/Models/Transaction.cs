using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonzoSankey.Services.Models
{
    public class Transaction
    {
        public Transaction(Mondo.Transaction transaction)
        {
            this.Id = transaction.Id;
            this.Created = transaction.Created;
            this.AmountInPence = transaction.Amount;
            this.Merchant = transaction.Merchant;
            this.Category = transaction.Category;
        }

        public string Id { get; set; }

        public DateTime Created { get; set; }

        public float AmountInPence { get; set; }

        public Mondo.Merchant Merchant { get; set; }

        public string Category { get; set; } // TODO: look at turning this into an enum? Causes issues in the future with new / custom categories

        public bool Include { get; set; } // Can't do until redo the client
    }
}
