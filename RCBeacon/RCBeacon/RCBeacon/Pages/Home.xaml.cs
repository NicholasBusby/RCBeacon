using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RCBeacon.Pages
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        public void facebookLogoutClicked(object sender, EventArgs args)
        {
            (App.Current as App).LogOutOfFacebook();
        }
    }
}
