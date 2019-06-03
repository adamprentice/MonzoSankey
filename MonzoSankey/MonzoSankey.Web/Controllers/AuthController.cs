using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MonzoApi.Services;
using MonzoApi.Services.Helpers;

namespace MonzoSankey.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IMonzoAuthorizationClient authClient;
        private MonzoSettings settings;

        public AuthController(IOptions<MonzoSettings> settings)
        {
            this.settings = settings.Value;

            this.authClient = new MonzoAuthorizationClient(this.settings.ClientId, this.settings.ClientSecret, this.settings.ApiBaseUrl);
        }

        public IActionResult Login()
        {
            var state = StringHelpers.RandomString(50);

            var redirectUrl = Url.Action("OAuthCallback", "Auth", null, Request.Scheme);

            var loginPageUrl = authClient.GetAuthUrl(state, redirectUrl);

            return Redirect(loginPageUrl);
        }

        public async Task<ActionResult> OAuthCallback(string code, string state)
        {
            var redirectUrl = Url.Action("OAuthCallback", "Auth", null, Request.Scheme);

            var accessToken = await this.authClient.GetAccessTokenAsync(code, redirectUrl);

            return null; // Need to save the access token somewhere, possibly against the user id and send back the user id to the client?
        }
    }

    
}