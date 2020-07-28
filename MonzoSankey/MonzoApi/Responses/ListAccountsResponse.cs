using MonzoApi.Core.Models;
using MonzoSankey.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonzoApi.Services.Responses
{
    public class ListAccountsResponse
    {
        public List<Account> Accounts { get; set; }
    }
}
