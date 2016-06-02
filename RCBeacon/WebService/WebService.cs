using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Auth;

namespace WebService
{
    public class WebService : IWebService
    {
        private Account _account;
        public WebService(Account account)
        {
            _account = account;
        }

        public async Task<Response> Get(Uri url, Dictionary<string, string> parameters)
        {
            return await makeAPICall("GET", url, parameters);
        }

        private async Task<Response> makeAPICall(string verb, Uri url, Dictionary<string, string> parameters)
        {
            var request = new OAuth2Request(verb, url, parameters, _account);
            var response = await request.GetResponseAsync();
            return response;
        }
    }
}
