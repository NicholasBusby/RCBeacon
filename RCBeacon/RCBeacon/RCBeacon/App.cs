using RCBeacon.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Auth;
using Xamarin.Forms;

namespace RCBeacon
{
    public class App : Application
    {
        private Account facebookAccount;
        public App()
        {
            if (FacebookAccount != null)
            {
                MainPage = new Home();
            }
            else
            {
                MainPage = new Login();
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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

        public void LogOutOfFacebook()
        {
            FacebookAccount = null;
            MainPage = new Login();
        }

        public void SuccessfulLoginAction()
        {
            MainPage = new Home();
        }
    }
}
