using Xamarin.Forms.Platform.iOS;
using RCBeacon.iOS.Renderers;
using RCBeacon.Pages;
using System;
using Xamarin.Auth;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(FacebookLogin), typeof(FacebookLoginRenderer))]

namespace RCBeacon.iOS.Renderers
{
	public class FacebookLoginRenderer : PageRenderer
	{
		private bool IsShown;
		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			if (!IsShown) {

				IsShown = true;

				var auth = new OAuth2Authenticator("272640903085791", string.Empty,
					new Uri("https://m.facebook.com/dialog/oauth/"),
					new Uri("http://www.facebook.com/connect/login_success.html"));

				auth.Completed += Auth_Completed;

				PresentViewController (auth.GetUI(), true, null);
			}
		}

		private void Auth_Completed(object sender, AuthenticatorCompletedEventArgs e)
		{
			if (e.IsAuthenticated)
			{
				var currentApp = (App.Current as App);
				currentApp.FacebookAccount = e.Account;
				currentApp.SuccessfulLoginAction();
			}
		}
	}
}