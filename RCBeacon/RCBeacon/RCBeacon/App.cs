using Akavache;
using IOCService;
using PersistanceService;
using RCBeacon.Pages;
using System.Threading.Tasks;
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
            MainPage = new Page();
            Task.Run(() => {
                SetThingsUp();
                });
        }

        private void authNavigation()
        {
            if (GetAccount().Result != null)
            {
                Device.BeginInvokeOnMainThread(() => MainPage = new Beacon());
            }
            else
            {
                Device.BeginInvokeOnMainThread(() => MainPage = new Login());
            }
        }

        private void SetThingsUp()
        {
            UnityIOCService.Initialize();
            BlobCache.ApplicationName = "RCBeacon";
            webService = UnityIOCService.Resolve<IWebService>();
            persistance = UnityIOCService.Resolve<IPersistanceService>();
            SetAccount(null);
            authNavigation();
        }

        protected override void OnSleep()
        {
            BlobCache.Shutdown().Wait();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public async Task<Account> GetAccount()
        {
            var account = await persistance?.GetObject<Account>(accountKey);
            return account;
        }

        public async void SetAccount(Account account)
        {
            if (account == null)
                await persistance?.RemoveFromMemory(accountKey);
            else
                await persistance?.InsertToMemory(accountKey, account);
        }

        public void LogOutOfFacebook()
        {
            SetAccount(null);
            authNavigation();
        }

        public void SuccessfulLoginAction()
        {
            authNavigation();
        }
    }
}
