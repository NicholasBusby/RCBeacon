using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using RCBeacon.SharedInterfaces;
using System;
using System.Threading.Tasks;
using Windows.UI.Popups;

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
            string message = string.Empty;
            var success = false;

            try
            {
                if(user == null)
                {
                    user = await BeaconItemManager.DefaultManager.CurrentClient.LoginAsync(MobileServiceAuthenticationProvider.Facebook);
                    if (user != null)
                    {
                        success = true;
                        message = $"You are now signed-in as {user.UserId}.";
                    }
                }
                success = true;
            }
            catch(Exception ex)
            {
                message = $"Authentication Failed: {ex.Message}";
            }

            await new MessageDialog(message, "Sign-in result").ShowAsync();
            return success;
        }
    }
}
