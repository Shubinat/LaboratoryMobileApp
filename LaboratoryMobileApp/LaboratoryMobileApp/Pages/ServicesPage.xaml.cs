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
    public partial class ServicesPage : ContentPage
    {
        public ServicesPage()
        {
            InitializeComponent();
        }

        private void LVServices_Refreshing(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            UpdateList();
        }
        private async void UpdateList()
        {
            try
            {
                LVServices.ItemsSource = await RestService.GetAsync<List<Service>>("Services");
            }
            catch (Exception)
            {
                Message.ShowShort("Произошла ошибка");
            }

            LVServices.IsRefreshing = false;
        }

        private void LVServices_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new Pages.CurrentServicePage(e.Item as Service));
        }
    }
}