using MonzoApi.Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace MonzoApi.Services
{
    public interface IMonzoAuthorizationClient
    {
        string GetAuthUrl(string state, string redirectUri);

        Task<AccessToken> GetAccessTokenAsync(string authCode, string redirectUri, CancellationToken cancelToken = new CancellationToken());
    }
}