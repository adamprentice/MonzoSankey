using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonzoApi.Services.Models
{
    public class AccessToken
    {
        private int _expiresIn { get; set; }
        [JsonProperty(PropertyName = "access_token")]
        public string Value { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn {
            get
            {
                return this._expiresIn;
            }

            set 
            {
                this.Expires = DateTime.UtcNow.AddSeconds(value);
                this._expiresIn = value;
            } 
        }

        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; }

        public DateTime Expires { get; set; }
    }
}
