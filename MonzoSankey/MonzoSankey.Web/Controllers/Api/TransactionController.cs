using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonzoSankey.Services;
using MonzoSankey.Services.Models;

namespace MonzoSankey.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private ITransactionService transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        [HttpGet("[action]")]
        public async Task<int> Transactions()
        {            
            MonzoClient.Login(); // This is nasty and need to do an actual auth flow, but will work for now.

            var transactions = await this.transactionService.GetTransactions(DateTime.UtcNow.AddMonths(-1), DateTime.UtcNow);

            return transactions.Count();
        }
    }
}