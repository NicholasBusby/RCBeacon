using Akavache;
using IOCService;
using Microsoft.WindowsAzure.MobileServices;
using PersistanceService;
using RCBeacon.Pages;
using RCBeacon.SharedInterfaces;
using System.Threading.Tasks;
using WebService;
using Xamarin.Forms;

namespace RCBeacon
{
    public class App : Application
    {
        public IWebService webService;
        public IPersistanceService persistance;
        private const string accountKey = "facebookAccount";

        public const string applicationURL = "https://microsoft-apiappea18178105be4e03a42316ee566c0e5e.azurewebsites.net";
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

        private void SetThingsUp()
        {
            UnityIOCService.Initialize();
            BlobCache.ApplicationName = "RCBeacon";
            webService = UnityIOCService.Resolve<IWebService>();
            persistance = UnityIOCService.Resolve<IPersistanceService>();

            Device.BeginInvokeOnMainThread(() => MainPage = new Login());
        }

        protected override void OnSleep()
        {
            BlobCache.Shutdown().Wait();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
