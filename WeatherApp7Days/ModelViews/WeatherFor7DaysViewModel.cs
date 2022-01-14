using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp7Days.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatherApp7Days.ModelViews
{
 
    internal class WeatherFor7DaysViewModel : BaseViewModel
    {
        public  Models.WeatherModel WeatherModel { get; set; }

        public List<Models.Daily> DailyWeather { get; set; }

       public string TimeZone { get; set; }

        public ICommand CurrentLocation { get; set; }
        

        public string APIKey = "103ed11412b1c2fdfab983512adf688c";

        public WeatherFor7DaysViewModel()
        {
            Task.Run(async () =>
            {
                WeatherModel = await Services.APIComunnication.GetWeatherAsync($"lat=33&lon=-94&exclude=hourly,current,minutely,alerts&appid={APIKey}");
                DailyWeather = WeatherModel.Daily;
                TimeZone = WeatherModel.Timezone;
            }).Wait();

            CurrentLocation = new Command(async () =>
            {
                try
                {
                    var location = await Geolocation.GetLastKnownLocationAsync();

                    if (location != null)
                    {
                        WeatherModel = await Services.APIComunnication.GetWeatherAsync($"lat={Convert.ToInt32(location.Latitude)}&lon={Convert.ToInt32(location.Longitude)}&appid={APIKey}");
                        DailyWeather = WeatherModel.Daily;
                        TimeZone = WeatherModel.Timezone;
                        OnPropertyChanged(nameof(WeatherModel));
                        OnPropertyChanged(nameof(DailyWeather));
                    }
                }
                catch (FeatureNotSupportedException fnsEx)
                {
                    // Handle not supported on device exception
                }
                catch (FeatureNotEnabledException fneEx)
                {
                    // Handle not enabled on device exception
                }
                catch (PermissionException pEx)
                {
                    // Handle permission exception
                }
                catch (Exception ex)
                {
                    // Unable to get location
                }
            });

        }


    }
}
