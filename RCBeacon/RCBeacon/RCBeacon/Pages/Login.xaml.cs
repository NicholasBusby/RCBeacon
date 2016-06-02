using System;
using Xamarin.Forms;

namespace RCBeacon.Pages
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        public void facebookLoginClicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new FacebookLogin();
        }
    }
}
