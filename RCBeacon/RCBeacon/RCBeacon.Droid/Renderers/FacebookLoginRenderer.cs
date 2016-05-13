using Android.App;
using RCBeacon.Droid.Renderers;
using RCBeacon.Pages;
using System;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FacebookLogin), typeof(FacebookLoginRenderer))]

namespace RCBeacon.Droid.Renderers
{
    public class FacebookLoginRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var activity = this.Context as Activity;

            var auth = new OAuth2Authenticator("272640903085791", string.Empty,
                new Uri("https://m.facebook.com/dialog/oauth/"),
                new Uri("http://www.facebook.com/connect/login_success.html"));

            auth.Completed += Auth_Completed;

            activity.StartActivity(auth.GetUI(activity));
        }

        private void Auth_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                (App.Current as App).SuccessfulLoginAction();
            }
        }
    }
}