using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;

namespace RCBeacon.Pages
{
    public partial class Beacon : TabbedPage
    {
        public Beacon()
        {
            var navigationPage = new NavigationPage(new MyBeacon());
            //navigationPage.Icon = "schedule.png";
            navigationPage.Title = "My Beacon";

            //Children.Add(new TodayPageCS());
            //Children.Add(navigationPage);
        }
    }
}
