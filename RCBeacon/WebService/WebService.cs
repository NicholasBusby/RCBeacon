using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace WebService
{
    public class WebService : IWebService
    {
        public string GET(Uri url, Dictionary<string, string> parameters, bool outputJson = true)
        {
            return makeAPICall("GET", url, parameters, outputJson);
        }

        private string makeAPICall(string verb, Uri url, Dictionary<string, string>, bool outputJson = true)
        {
            var request = new OAuth2Request
        }
    }
}
