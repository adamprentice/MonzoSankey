using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonzoSankey.Core.Models
{
    public class Transaction
    {
        public string Id { get; set; }

        public string AccountId { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Settled { get; set; }

        public float Amount { get; set; }

        public Merchant Merchant { get; set; }

        public string Category { get; set; } // TODO: look at turning this into an enum? Causes issues in the future with new / custom categories

        public string Currency { get; set; }


    }
}
