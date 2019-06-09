using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MonzoApi.Services
{
    public abstract class Client
    {
        protected string BaseDomain { get; }
        protected readonly HttpClient _httpClient;

        public Client(string baseDomain, string subDomain = "")
        {
            var uri = new Uri(baseDomain);
            this.BaseDomain = uri.Host;

            this._httpClient = new HttpClient { BaseAddress = new Uri($"https://{(string.IsNullOrEmpty(subDomain) ? string.Empty : subDomain + ".")}{this.BaseDomain}") };
        }
    }
}
