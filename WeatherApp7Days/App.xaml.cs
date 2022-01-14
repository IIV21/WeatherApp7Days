using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp7Days
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new WeatherFor7Days();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
