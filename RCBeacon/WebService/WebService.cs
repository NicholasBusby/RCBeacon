using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reactive.Linq;
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
            var response = await Observable.FromAsync(() => makeAPICall("GET", url, parameters))
                .Timeout(TimeSpan.FromSeconds(15))
                .Retry(5)
                .Catch<Response, Exception>(ex => Observable.Return(new Response(new HttpResponseMessage(HttpStatusCode.BadRequest))));

            return response;
        }

        private async Task<Response> makeAPICall(string verb, Uri url, Dictionary<string, string> parameters)
        {
            var request = new OAuth2Request(verb, url, parameters, _account);
            var response = await request.GetResponseAsync();
            return response;
        }
    }
}
