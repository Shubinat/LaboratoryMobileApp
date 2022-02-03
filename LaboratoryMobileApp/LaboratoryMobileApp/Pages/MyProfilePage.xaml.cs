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
    public partial class MyProfilePage : ContentPage
    {
        public MyProfilePage(User user)
        {
            InitializeComponent();
            BindingContext = user;
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void BtnReLogin_Clicked(object sender, EventArgs e)
        {
            App.LoginUser = null;
            Navigation.PushAsync(new AutorizationPage());
        }

        private void LVServices_Refreshing(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void BtnAddService_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddUserServicePage());
        }

        private async void LVServices_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (e.Item as UserService);
            var result  = await DisplayAlert(item.Service.Name, $"Вы действительно хотить отменить запись на {item.DateText}", "Удалить", "Отмена");
            if(result == true)
            {
                try
                {
                    await RestService.DeleteAsync($"UserServices?userServiceID={item.ID}");
                    UpdateList();
                }
                catch (Exception)
                {
                    Message.ShowShort("Произошла ошибка");
                }
                
            }
        }

        private async void UpdateList()
        {
            try
            {
                LVServices.ItemsSource = await RestService.GetAsync<List<UserService>>($"UserServices?userID={App.LoginUser.ID}");
            }
            catch (Exception)
            {
                Message.ShowShort("Произошла ошибка");
            }
            LVServices.IsRefreshing = false;
        }

        private void BtnEditProfile_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditUserPage(App.LoginUser));
        }
    }
}