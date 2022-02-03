using LaboratoryMobileApp.Models;
using LaboratoryMobileApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaboratoryMobileApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            DPickerBirthDate.MaximumDate = DateTime.Now;
        }

        private async void BtnRegistration_Clicked(object sender, EventArgs e)
        {


            if( !string.IsNullOrWhiteSpace(EntrySurname.Text) && 
                !string.IsNullOrWhiteSpace(EntryName.Text) && 
                !string.IsNullOrWhiteSpace(EntryPassportSeria.Text) &&
                !string.IsNullOrWhiteSpace(EntryPassportNumber.Text) &&
                !string.IsNullOrWhiteSpace(EntryPolicyNumber.Text) &&
                !string.IsNullOrWhiteSpace(EntryPhoneNumber.Text) &&
                !string.IsNullOrWhiteSpace(EntryEmail.Text) &&
                !string.IsNullOrWhiteSpace(EntryLogin.Text) &&
                !string.IsNullOrWhiteSpace(EntryPassword.Text) &&
                !string.IsNullOrWhiteSpace(EntryRePassword.Text) &&
                DPickerBirthDate.Date != null)
            {
                if (EntryPassword.Text.Trim() == EntryRePassword.Text.Trim())
                {
                    RegScreen.IsEnabled = false;
                    LoadingScreen.IsVisible = true;

                    var regUser = new User(EntryLogin.Text.Trim(), EntryPassword.Text.Trim(), EntryName.Text.Trim(), EntrySurname.Text.Trim(),
                        EntryPatronimyc.Text.Trim(), DPickerBirthDate.Date, EntryPolicyNumber.Text.Trim(),
                        EntryPassportNumber.Text.Trim(), EntryPassportSeria.Text.Trim(), EntryPhoneNumber.Text.Trim(), EntryEmail.Text.Trim());
                    try
                    {

                        await RestService.PostAsync("Users/Registration", regUser);
                        await Navigation.PopAsync();
                    }
                    catch (HttpRequestException)
                    {
                        Message.ShowShort("Произошла ошибка при регистрации.");
                    }
                    catch
                    {
                        Message.ShowShort("Отсутствует соединение с интернетом.");
                    }

                }
                else
                {
                    Message.ShowShort("Введенные пароли не совпадают");
                }
            }
            else
            {
                Message.ShowShort("Не все поля заполнены");
            }
            RegScreen.IsEnabled = true;
            LoadingScreen.IsVisible = false;
        }
    }
}