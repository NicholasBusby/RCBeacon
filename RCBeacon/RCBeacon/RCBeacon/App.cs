using IOCService;
using PersistanceService;
using RCBeacon.Pages;
using Xamarin.Auth;
using Xamarin.Forms;

namespace RCBeacon
{
    public class App : Application
    {
        private Account facebookAccount;
        private const string applicationName = "RCBeacon";
        public App()
        {
            if (FacebookAccount != null)
            {
                MainPage = new Beacon();
            }
            else
            {
                MainPage = new Login();
            }
        }

        protected override void OnStart()
        {
            SetThingsUp();
        }

        private void SetThingsUp()
        {
            UnityIOCService.Initialize();
            Akavache.BlobCache.ApplicationName = "RCBeacon";
            var service = UnityIOCService.Resolve<IPersistanceService>();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public Account FacebookAccount
        {
            get
            {
                return facebookAccount;
            }
            set
            {
                facebookAccount = value;
            }
        }

        public object BlobCache { get; private set; }

        public void LogOutOfFacebook()
        {
            FacebookAccount = null;
            MainPage = new Login();
        }

        public void SuccessfulLoginAction()
        {
            MainPage = new Beacon();
        }
    }
}
