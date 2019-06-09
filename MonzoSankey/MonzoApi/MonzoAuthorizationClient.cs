using MonzoApi.Services.Helpers;
using MonzoApi.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonzoApi.Services
{
    public class MonzoAuthorizationClient : Client, IMonzoAuthorizationClient
    {
        private string ClientId { get; }

        private string ClientSecret { get; }

        public MonzoAuthorizationClient(string clientId, string clientSecret, string baseDomain = "https://monzo.com", string apiSubDomain = "api")
            : base(baseDomain, apiSubDomain)
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
        }

        public string GetAuthUrl(string state, string redirectUri)
        {
            var queryValues = new Dictionary<string, string>
            {
                { "response_type", "code" },
                { "client_id", ClientId }
            };

            if (!string.IsNullOrWhiteSpace(state))
            {
                queryValues.Add("state", state);
            }

            if (!string.IsNullOrWhiteSpace(redirectUri))
            {
                queryValues.Add("redirect_uri", WebUtility.UrlEncode(redirectUri));
            }

            return UrlHelper.BuildApiUrl($"https://auth.{this.BaseDomain}/", queryValues);
        }

        public async Task<AccessToken> GetAccessTokenAsync (string authCode, string redirectUri, CancellationToken cancelToken = new CancellationToken())
        {
            var formValues = new Dictionary<string, string>
            {
                { "client_id", ClientId },
                { "client_secret", ClientSecret },
                { "grant_type", "authorization_code" },
                { "code", authCode },
                { "redirect_uri", redirectUri }
            };

            return await this.AuthorizeAsync(formValues, cancelToken);
        }

        private async Task<AccessToken> AuthorizeAsync(Dictionary<string, string> formValues, CancellationToken cancellationToken = new CancellationToken())
        {
            var response = await _httpClient.PostAsync("oauth2/token", new FormUrlEncodedContent(formValues), cancellationToken).ConfigureAwait(false);
            var body = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<AccessToken>(body);
        }
    }
}
