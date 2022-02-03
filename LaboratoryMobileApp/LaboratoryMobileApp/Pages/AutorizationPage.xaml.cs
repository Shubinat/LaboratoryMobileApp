using Android.Widget;
using LaboratoryMobileApp.Models;
using LaboratoryMobileApp.Pages;
using LaboratoryMobileApp.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LaboratoryMobileApp.Pages
{
    public partial class AutorizationPage : ContentPage
    {
        public AutorizationPage()
        {
            InitializeComponent();
        }

        private void Registration(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistrationPage());
        }

        private void LogInAsGuest(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestPage());
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(EntryLogin.Text.Trim()) && !string.IsNullOrWhiteSpace(EntryPassword.Text.Trim()))
            {
                AutorizationScreen.IsEnabled = false;
                LoadingScreen.IsVisible = true;
                try
                {
                    var authUser = await RestService.PostAsync<User>("Users/Autorization", new User(EntryLogin.Text, EntryPassword.Text));
                    App.LoginUser = authUser;
                    await Navigation.PushAsync(new MyProfilePage(authUser));
                }
                catch (System.Net.Http.HttpRequestException)
                {
                    Message.ShowShort("Неправильный логин или пароль.");
                }
                catch (Java.Net.SocketException)
                {
                    Message.ShowShort("Отсутствует подключение к интернету.");
                }
                catch
                {
                    Message.ShowShort("Неизвестная ошибка, повторие попытку позже.");
                }
                AutorizationScreen.IsEnabled = true;
                LoadingScreen.IsVisible = false;
            }
            else
            {
                Message.ShowShort("Заполите оба поля.");
            }
        }
    }
}
