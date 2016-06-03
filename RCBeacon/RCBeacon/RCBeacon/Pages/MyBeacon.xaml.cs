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
    public partial class MyBeacon : ContentPage
    {
        public MyBeacon()
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
            var nameRequest = new OAuth2Request("GET", new Uri("https://graph.facebook.com/v2.6/me"), null, account);
            var nameResponse = nameRequest.GetResponseAsync().Result;
            var nameResponseText = nameResponse.GetResponseText();
            var nameJsonResponse = JObject.Parse(nameResponseText);

            var photoRequest = new OAuth2Request("GET", new Uri("https://graph.facebook.com/v2.6/me/picture"), new Dictionary<string, string> { { "height", "500" } }, account);
            var photoResponse = photoRequest.GetResponseAsync().Result;

            userName.Text = nameJsonResponse.Value<string>("name");
            userImage.Source = ImageSource.FromUri(photoResponse.ResponseUri);
        }
    }
}
