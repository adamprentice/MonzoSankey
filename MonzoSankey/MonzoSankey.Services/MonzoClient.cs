using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Mondo;

namespace MonzoSankey.Services
{
    public class MonzoClient
    {
        private IMondoAuthorizationClient authClient;
        internal static IMondoClient Client;

        public MonzoClient()
        {
            //this.authClient = new MondoAuthorizationClient(config["MonzoClient:ClientId"], config["MonzoClient:ClientSecret"], config["MonzoClient:ApiBaseUrl"]);
        }

        public static void Login()
        {
            // Need to actually sort out logging in properly, so that it can work for everyone
            Client = new MondoClient(ConfigurationManager.AppSettings["MonzoClient:AccessToken"], ConfigurationManager.AppSettings["MonzoClient:ApiBaseUrl"]);
        }
    }
}
