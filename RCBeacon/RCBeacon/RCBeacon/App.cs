using Akavache;
using IOCService;
using Microsoft.WindowsAzure.MobileServices;
using PersistanceService;
using RCBeacon.Pages;
using RCBeacon.SharedInterfaces;
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
        private const string accountKey = "facebookAccount";

        public const string applicationURL = "https://microsoft-apiappea18178105be4e03a42316ee566c0e5e.azurewebsites.net/";
        public static MobileServiceClient client = new MobileServiceClient(applicationURL);

        public static IAuthenticate Authenticator { get; private set; }

        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }


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
            Task.Run(() => {
                SetAccount(null);
                authNavigation();
                });
        }

        public void SuccessfulLoginAction()
        {
            Task.Run(() => authNavigation());
        }
    }
}
