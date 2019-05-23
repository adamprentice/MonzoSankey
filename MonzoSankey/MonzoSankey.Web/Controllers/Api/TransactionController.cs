﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonzoSankey.Services.Models;
using MonzoSankey.Services.Transactions;

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
        public SankeyResponse Transactions()
        {
            var client = new MonzoApi.MonzoClient(); // Needs to be one per user due to authentication, will need to be attached to user object or cached once logged in.

            var sankeyResponse = this.transactionService.GetSankeyDataForTransactions(client, DateTime.UtcNow.AddMonths(-1), DateTime.UtcNow);

            return sankeyResponse;
        }
    }
}