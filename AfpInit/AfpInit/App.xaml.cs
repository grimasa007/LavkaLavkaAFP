using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AfpInit
{
    public partial class App : Application
    {
        private static int _orderSum;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new IntroPage ());
        }

        protected override void OnSleep()
        {
            
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
