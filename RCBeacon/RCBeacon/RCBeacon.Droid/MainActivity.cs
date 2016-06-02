using Akavache;
using Android.App;
using Android.Content.PM;
using Android.OS;
using XLabs.Forms;
using XLabs.Forms.Droid;

namespace RCBeacon.Droid
{
    [Activity(Label = "RCBeacon", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : XFormsApplicationDroid
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

