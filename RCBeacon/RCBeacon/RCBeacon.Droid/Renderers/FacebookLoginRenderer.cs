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

            var auth = new OAuth2Authenticator(Resources.GetString(Resource.String.facebook_app_id), string.Empty,
                new Uri("https://m.facebook.com/dialog/oauth/"),
                new Uri("http://www.facebook.com/connect/login_success.html"));

            auth.Completed += Auth_Completed;

            activity.StartActivity(auth.GetUI(activity));
        }

        private void Auth_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                var currentApp = (App.Current as App);
                currentApp.SetAccount(e.Account);
                currentApp.SuccessfulLoginAction();
            }
        }
    }
}