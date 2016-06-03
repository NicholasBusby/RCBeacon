using Akavache;
using IOCService;
using PersistanceService;
using RCBeacon.Pages;
using WebService;
using Xamarin.Auth;
using Xamarin.Forms;

namespace RCBeacon
{
    public class App : Application
    {
        public IWebService webService;
        public IPersistanceService persistance;
        private const string applicationName = "RCBeacon";
        private const string accountKey = "facebookAccount";
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
            BlobCache.ApplicationName = "RCBeacon";
            webService = UnityIOCService.Resolve<IWebService>();
            persistance = UnityIOCService.Resolve<IPersistanceService>();
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
                return persistance?.GetObject<Account>(accountKey).Result;
            }
            set
            {
                persistance?.InsertToMemory(accountKey, value);
            }
        }

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
