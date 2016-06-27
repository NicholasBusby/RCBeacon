using Microsoft.WindowsAzure.MobileServices;
using RCBeacon.SharedInterfaces;
using System;
using System.Threading.Tasks;

namespace RCBeacon.UWP
{
    public sealed partial class MainPage : IAuthenticate
    {
        private MobileServiceUser user;

        public MainPage()
        {
            this.InitializeComponent();
            RCBeacon.App.Init(this);
            LoadApplication(new RCBeacon.App());
        }

        public async Task<bool> Authenticate()
        {
            var success = false;
            try
            {
                if(user == null)
                {
                    user = await RCBeacon.App.client.LoginAsync(MobileServiceAuthenticationProvider.Facebook);
                    if (user != null)
                    {
                        var messageDialog = new Windows.UI.Popups.MessageDialog(
                        string.Format("you are now logged in - {0}", user.UserId), "Authentication");
                        messageDialog.ShowAsync();
                    }
                }
                success = true;
            }
            catch(Exception ex)
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog(ex.Message, "Authentication Failed");
                messageDialog.ShowAsync();
            }
            return success;
        }
    }
}
