using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MonzoApi.Services;
using MonzoSankey.Services.Models;
using MonzoSankey.Services.Transactions;

namespace MonzoSankey.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService transactionService;
        private readonly MonzoSettings settings;

        public TransactionController(ITransactionService transactionService, IOptions<MonzoSettings> settings)
        {
            this.transactionService = transactionService;
            this.settings = settings.Value;
        }

        [HttpGet("[action]")]
        public async Task<SankeyResponse> Transactions()
        {            
            var accessToken = settings.AccessToken;  // Needs to be one per user due to authentication, will need to be attached to user object or cached once logged in.

            using (var client = new MonzoClient(accessToken, this.settings.BaseUrl, this.settings.ApiSubDomain))
            {
                var transactions = await client.GetTransactions(new string[]{ settings.AccountId }, DateTime.Now.AddMonths(-1), DateTime.Now);

                return this.transactionService.GetSankeyDataForTransactions(transactions);
            }
        }
    }
}