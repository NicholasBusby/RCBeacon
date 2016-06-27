using RCBeacon.Pages;
using RCBeacon.UWP.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.UWP;
using Xamarin.Forms;
using Xamarin.Auth;
using Windows.Security.Authentication.Web;
using Windows.UI.Xaml;
using Facebook;
using Newtonsoft.Json.Linq;
using Microsoft.WindowsAzure.MobileServices;
using System.Net.Http;
using System.Threading;

[assembly: ExportRenderer(typeof(FacebookLogin), typeof(FacebookLoginRenderer))]

namespace RCBeacon.UWP.Renderers
{
    public class FacebookLoginRenderer: PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            RCBeacon.App.client.LoginAsync(MobileServiceAuthenticationProvider.Facebook);
            //loginToFacebook();
        }

        //private async void loginToFacebook()
        //}

        private string ParseAuthenticationResult(FacebookClient fb, WebAuthenticationResult result)
        {
            switch (result.ResponseStatus)
            {
                case WebAuthenticationStatus.ErrorHttp:
                    return "Error";
                case WebAuthenticationStatus.Success:
                    var oAuthResult = fb.ParseOAuthCallbackUrl(new Uri(result.ResponseData));
                    AuthSuccess(oAuthResult);
                    return oAuthResult.AccessToken;
                case WebAuthenticationStatus.UserCancel:
                    return "Operation aborted";
            }
            return null;
        }

        private async void AuthSuccess(FacebookOAuthResult facebookResult)
        {
            var accessToken = facebookResult.AccessToken;
            var fbAccount = new Account();

            fbAccount.Properties.Add("state", facebookResult.State);
            fbAccount.Properties.Add("access_token", facebookResult.AccessToken);
            fbAccount.Properties.Add("expires_in", ((int)(facebookResult.Expires - DateTime.Now).TotalSeconds).ToString());

            
            var currentApp = (RCBeacon.App.Current as RCBeacon.App);
            currentApp.SetAccount(fbAccount);
            currentApp.SuccessfulLoginAction();
        }
    }
}
