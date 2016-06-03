using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
            GetUserNameAndImage();
        }

        private async void GetUserNameAndImage()
        {
            var account = (App.Current as App).FacebookAccount;

            var nameResponse = await (App.Current as App).webService.Get(account, new Uri("https://graph.facebook.com/v2.6/me"), null);
            var nameResponseText = nameResponse.GetResponseText();
            var nameJsonResponse = JObject.Parse(nameResponseText);
            
            var photoResponse = await (App.Current as App).webService.Get(account, new Uri("https://graph.facebook.com/v2.6/me/picture"), new Dictionary<string, string> { { "height", "500" } });

            userName.Text = nameJsonResponse.Value<string>("name");
            userImage.Source = ImageSource.FromUri(photoResponse.ResponseUri);
        }
    }
}
