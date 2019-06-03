using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonzoApi.Services.Models
{
    public class AccessToken
    {
        [JsonProperty(PropertyName = "access_token")]
        public string Value { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; }
    }
}
