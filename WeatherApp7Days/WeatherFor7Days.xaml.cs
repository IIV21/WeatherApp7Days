using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp7Days
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherFor7Days : ContentPage
    {
        public WeatherFor7Days()
        {
            InitializeComponent();
            BindingContext = new ModelViews.WeatherFor7DaysViewModel();
        }
    }
}