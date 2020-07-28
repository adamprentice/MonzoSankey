using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MonzoApi.Services;
using MonzoApi.Services.Helpers;
using Jose;
using MonzoApi.Services.Models;

namespace MonzoSankey.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IMonzoAuthorizationClient authClient;
        private readonly MonzoSettings settings;

        public AuthController(IOptions<MonzoSettings> settings)
        {
            this.settings = settings.Value;

            this.authClient = new MonzoAuthorizationClient(this.settings.ClientId, this.settings.ClientSecret, this.settings.BaseUrl, this.settings.ApiSubDomain);
        }

        public IActionResult Login()
        {
            if (this.Request.Cookies.ContainsKey("jwt"))
            {
                try
                {
                    var jwt = JWT.Decode<AccessToken>(this.Request.Cookies["jwt"], this.settings.EncryptKey, JwsAlgorithm.HS256);

                    if (DateTime.UtcNow < jwt.Expires)
                    {
                        return new RedirectResult("/chart");
                    }
                }
                catch
                {
                    // Encrypt key has probably changed so can't be used
                }
                
            }
            var redirectUrl = Url.Action("OAuthCallback", "Auth", null, Request.Scheme);

            var loginPageUrl = authClient.GetAuthUrl(this.settings.State, redirectUrl);

            return Redirect(loginPageUrl);
        }

        public async Task<ActionResult> OAuthCallback(string code, string state)
        {
            if (this.settings.State != state)
            {
                var view = View("Error");
                view.StatusCode = (int)HttpStatusCode.Forbidden;

                return view;
            }

            var redirectUrl = Url.Action("OAuthCallback", "Auth", null, Request.Scheme);

            var accessToken = await this.authClient.GetAccessTokenAsync(code, redirectUrl);

            var token = JWT.Encode(accessToken, this.settings.EncryptKey, JwsAlgorithm.HS256);

            Response.Cookies.Append("jwt", token);

            return new RedirectResult("/chart");
        }
    }
}