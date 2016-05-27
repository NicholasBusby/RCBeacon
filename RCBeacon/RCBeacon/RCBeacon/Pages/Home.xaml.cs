using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;

namespace RCBeacon.Pages
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        public void facebookLogoutClicked(object sender, EventArgs args)
        {
            (App.Current as App).LogOutOfFacebook();
        }

        public void userNameClicked(object sender, EventArgs args)
        {
            var account = (App.Current as App).FacebookAccount;
            var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me"), null, account);
            var response = request.GetResponseAsync().Result;
            var responseText = response.GetResponseText();
            var jsonResponse = JObject.Parse(responseText);
            userName.Text = jsonResponse.Value<string>("name");
        }
    }
}
