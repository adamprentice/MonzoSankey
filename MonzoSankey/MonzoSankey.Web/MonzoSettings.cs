using MonzoApi.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonzoSankey.Web
{
    public class MonzoSettings
    {
        private string _state { get; set; }

        private byte[] _encryptKey { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string AccessToken { get; set; } // Remove when auth is done

        public string BaseUrl { get; set; }

        public string ApiSubDomain { get; set; }

        public string AccountId { get; set; } // Remove when Auth is done

        public string State {
            get {
                if (string.IsNullOrEmpty(this._state))
                {
                    this._state = StringHelpers.RandomString(50);                    
                }

                return this.State;
            }
        }

        public byte[] EncryptKey
        {
            get
            {
                if (this._encryptKey == null)
                {
                    this._encryptKey = Guid.NewGuid().ToByteArray();
                }

                return this._encryptKey;
            }
        }
    }
}
