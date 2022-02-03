using LaboratoryMobileApp.Models;
using LaboratoryMobileApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaboratoryMobileApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUserServicePage : ContentPage
    {
        public AddUserServicePage()
        {
            InitializeComponent();
        }

        private async void BtnAddUserService_Clicked(object sender, EventArgs e)
        {
            LoadingScreen.IsVisible = true;
            ServiceScreen.IsEnabled = false;
            ServiceScreen.IsVisible = false;

            try
            {
                var userService = new UserService()
                {
                    Date = DPickerServiceDate.Date,
                    UserID = App.LoginUser.ID,
                    ServiceID = (PickerServices.SelectedItem as Service).ID
                };
                await RestService.PostAsync("UserServices", userService);
                await Navigation.PopAsync();
            }
            catch (Exception)
            {
                Message.ShowShort("Произошла ошибка");
            }

            LoadingScreen.IsVisible = false;
            ServiceScreen.IsEnabled = true;
            ServiceScreen.IsVisible = true;
        }

        private void PickerServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedService = (PickerServices.SelectedItem as Service);
            EditorDescription.Text = selectedService.Description;
            EditorPrice.Text = selectedService.Price.ToString();
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            LoadingScreen.IsVisible = true;
            ServiceScreen.IsEnabled = false;
            ServiceScreen.IsVisible = false;
            try
            {
                DPickerServiceDate.MinimumDate = DateTime.Now;
                PickerServices.ItemsSource = await RestService.GetAsync<List<Service>>("Services");
            }
            catch (Exception)
            {
                Message.ShowShort("Произошла ошибка");
                await Navigation.PopAsync();
            }
            LoadingScreen.IsVisible = false;
            ServiceScreen.IsEnabled = true;
            ServiceScreen.IsVisible = true;
        }
    }
}