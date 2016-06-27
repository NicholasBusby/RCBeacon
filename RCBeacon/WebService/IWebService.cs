using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;

namespace WebService
{
    public interface IWebService
    {
        Task<Response> Get(Account account, Uri url, Dictionary<string, string> parameters);
        Task<JObject> Post(Uri url, JObject body);
    }
}
