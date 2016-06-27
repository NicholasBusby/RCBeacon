using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using Xamarin.Auth;
using Xamarin.Forms;

namespace RCBeacon.Pages
{
    public partial class MyBeacon : ContentPage
    {
        public MyBeacon()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
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
            var account = await (App.Current as App).GetAccount();

            var nameResponse = await (App.Current as App).webService.Get(account, new Uri("https://graph.facebook.com/v2.6/me"), null);
            var nameResponseText = nameResponse.GetResponseText();
            var nameJsonResponse = JObject.Parse(nameResponseText);
            
            var photoResponse = await (App.Current as App).webService.Get(account, new Uri("https://graph.facebook.com/v2.6/me/picture"), new Dictionary<string, string> { { "height", "500" } });

            var resp = await (App.Current as App).webService.Post(new Uri("https://microsoft-apiappea18178105be4e03a42316ee566c0e5e.azurewebsites.net/.auth/login/facebook"), JObject.Parse($"{{\"access_token\": \"{account.Properties["access_token"]}\" }}"));

            userName.Text = nameJsonResponse.Value<string>("name");
            userImage.Source = ImageSource.FromUri(photoResponse.ResponseUri);
        }
    }
}
