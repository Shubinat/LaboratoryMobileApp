using LaboratoryMobileApp.Models;
using LaboratoryMobileApp.Utils;
using Newtonsoft.Json;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaboratoryMobileApp
{
    public partial class App : Application
    {

        public static User LoginUser
        {
            get
            {
                if (Current.Properties.TryGetValue(nameof(LoginUser), out object user) && !string.IsNullOrWhiteSpace(user.ToString()))
                {
                    var loginUser = JsonConvert.DeserializeObject<User>(user.ToString());       
                    return loginUser;
                }
                return null;
            }
            set
            {
                Current.Properties[nameof(LoginUser)] = JsonConvert.SerializeObject(value);
                Current.SavePropertiesAsync();
            }
        }
        public App()
        {
            InitializeComponent();
            
            if(LoginUser == null)
            {
                MainPage = new NavigationPage(new Pages.AutorizationPage());
            }
            else
            {
                MainPage = new NavigationPage(new Pages.MyProfilePage(LoginUser));
            }
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
