using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Xamarin.Auth;

namespace WebService
{
    public class AuthWebService : IWebService
    {
        public async Task<Response> Get(Account account, Uri url, Dictionary<string, string> parameters)
        {
            var response = await Observable.FromAsync(() => makeAPICall(account, "GET", url, parameters))
                .Timeout(TimeSpan.FromSeconds(15))
                .Retry(5)
                .Catch<Response, Exception>(ex => Observable.Return(new Response(new HttpResponseMessage(HttpStatusCode.BadRequest))));

            return response;
        }

        public async Task<JObject> Post(Uri url, JObject body)
        {
            var client = new HttpClient();
            var response = await client.PostAsync(url, new StringContent(body.ToString(Newtonsoft.Json.Formatting.None)));
            var j = JObject.Parse(await response.Content.ReadAsStringAsync());
            return j;
        }

        private async Task<Response> makeAPICall(Account account, string verb, Uri url, Dictionary<string, string> parameters)
        {
            var request = new OAuth2Request(verb, url, parameters, account);
            var response = await request.GetResponseAsync();
            return response;
        }
    }
}
