using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Jose;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MonzoApi.Services;
using MonzoApi.Services.Models;
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
            var accessToken = JWT.Decode<AccessToken>(this.Request.Cookies["jwt"], this.settings.EncryptKey, JwsAlgorithm.HS256);

            using (var client = new MonzoClient(accessToken.Value, this.settings.BaseUrl, this.settings.ApiSubDomain))
            {
                var accounts = await client.GetAccounts();
                var transactions = await client.GetTransactions(accounts.Where(x => !x.Closed).Select(x => x.ID).ToArray(), DateTime.Now.AddMonths(-1), DateTime.Now);

                return this.transactionService.GetSankeyDataForTransactions(transactions);
            }
        }
    }
}