using MonzoApi.Services.Helpers;
using MonzoApi.Services.Models;
using MonzoApi.Services.Responses;
using MonzoSankey.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MonzoApi.Services
{
    public class MonzoClient : Client, IMonzoClient
    {
        public MonzoClient(string accessToken, string baseDomain = "https://monzo.com", string apiSubDomain = "api")
            : base(baseDomain, apiSubDomain)
        {
            this._httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public async Task<List<Transaction>> GetTransactions(string[] accountIds, DateTime? from = null, DateTime? to = null)
        {
            if (accountIds.Length == 0)
            {
                throw new ArgumentNullException(nameof(accountIds));
            }

            var queryValues = new Dictionary<string, string>
            {
                { "account_id", accountIds.FirstOrDefault()},
                { "expand[]", "merchant" }
            };

            var pagination = new Pagination
            {
                From = from,
                To = to
            };

            var url = UrlHelper.BuildApiUrl("transactions", queryValues, pagination);

            var response = await this.GetResponse<ListTransactionsResponse>(url);

            return response.Transactions;
        }

        private async Task<T> GetResponse<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            var responseBody = await response.Content.ReadAsStringAsync();

            // Insert Error catching
            return JsonConvert.DeserializeObject<T>(responseBody);
        }
    }
}
