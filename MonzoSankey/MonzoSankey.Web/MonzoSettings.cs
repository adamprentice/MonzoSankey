using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonzoSankey.Web
{
    public class MonzoSettings
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string AccessToken { get; set; } // Remove when auth is done

        public string ApiBaseUrl { get; set; }

        public string AccountId { get; set; } // Remove when Auth is done
    }
}
