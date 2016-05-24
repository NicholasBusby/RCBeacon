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

[assembly: ExportRenderer(typeof(FacebookLogin), typeof(FacebookLoginRenderer))]

namespace RCBeacon.UWP.Renderers
{
    public class FacebookLoginRenderer: PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var auth = new OAuth2Authenticator("272640903085791", string.Empty,
                new Uri("https://m.facebook.com/dialog/oauth/"),
                new Uri("http://www.facebook.com/connect/login_success.html"));

            auth.Completed += Auth_Completed;


            string SID = WebAuthenticationBroker.GetCurrentApplicationCallbackUri().ToString();
            System.Diagnostics.Debug.WriteLine(SID);
        }

        private void Auth_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            
        }
    }
}
