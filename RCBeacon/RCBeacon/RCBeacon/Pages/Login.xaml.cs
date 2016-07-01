using System;
using Xamarin.Forms;

namespace RCBeacon.Pages
{
    public partial class Login : ContentPage
    {
        bool authenticated = false;
        public Login()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (authenticated)
            {
                //logged in
            }
        }

        public async void facebookLoginClicked(object sender, EventArgs args)
        {
            if(App.Authenticator != null)
            {
                authenticated = await App.Authenticator.Authenticate();
            }
        }
    }
}
