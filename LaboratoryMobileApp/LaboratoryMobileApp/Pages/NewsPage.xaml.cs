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
    public partial class NewsPage : ContentPage
    {
        public NewsPage()
        {
            InitializeComponent();
           
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void LVNews_Refreshing(object sender, EventArgs e)
        {
            UpdateList();
        }
        
        private async void UpdateList()
        {
            try
            {
                LVNews.ItemsSource = await RestService.GetAsync<List<News>>("News");
            }
            catch (Exception)
            {
                Message.ShowShort("Произошла ошибка");
            }
            
            LVNews.IsRefreshing = false;
        }
    }
}