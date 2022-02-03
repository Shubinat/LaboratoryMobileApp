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
    public partial class EditUserPage : ContentPage
    {
        private User _user;
        public EditUserPage(User user)
        {
            InitializeComponent();
            _user = user;
            EntryEmail.Text = user?.Email;
            EntryPhoneNumber.Text = user?.PhoneNumber;
            ChangeEnabled(false);
        }

        private void CBoxEditPhoneNumber_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            ChangeEnabled(e.Value);
        }

        private void ChangeEnabled(bool value)
        {
            EntryOldPassword.IsEnabled = value;
            EntryNewPassword.IsEnabled = value;
            EntryRePassword.IsEnabled = value;
            LabelOldPassword.IsEnabled = value;
            LabelNewPassword.IsEnabled = value;
            LabelRePassword.IsEnabled = value;
        }

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {

            try
            {
                if (!string.IsNullOrWhiteSpace(EntryEmail.Text) &&
                    !string.IsNullOrWhiteSpace(EntryPhoneNumber.Text))
                {
                    if (CBoxEditPassword.IsChecked)
                    {
                        if (!string.IsNullOrWhiteSpace(EntryOldPassword.Text) &&
                            !string.IsNullOrWhiteSpace(EntryNewPassword.Text) &&
                            !string.IsNullOrWhiteSpace(EntryRePassword.Text))
                        {
                            if (EntryOldPassword.Text == App.LoginUser.Password)
                            {
                                if (EntryNewPassword.Text == EntryRePassword.Text)
                                {
                                    LoadingScreen.IsVisible = true;
                                    EditScreen.IsEnabled = false;

                                    App.LoginUser = await RestService.PutAsync<User>($"Users/EditProfile?userID={App.LoginUser.ID}",
                                        new { Email = EntryEmail.Text, PhoneNumber = EntryPhoneNumber.Text, Password = EntryNewPassword.Text });
                                    await Navigation.PopAsync();
                                }
                                else
                                {
                                    Message.ShowShort("Введенные пароли не овпадают");
                                }
                            }
                            else
                            {
                                Message.ShowShort("Неверный пароль");
                            }
                        }
                        else
                        {
                            Message.ShowShort("Поля не должны быть пустыми");
                        }
                    }
                    else
                    {
                        LoadingScreen.IsVisible = true;
                        EditScreen.IsEnabled = false;

                        App.LoginUser = await RestService.PutAsync<User>($"Users/EditProfile?userID={App.LoginUser.ID}", new { Email = EntryEmail.Text, PhoneNumber = EntryPhoneNumber.Text });
                        await Navigation.PopAsync();
                    }

                }
                else
                {
                    Message.ShowShort("Поля не должны быть пустыми");
                }

            }
            catch (Exception)
            {
                Message.ShowShort("Произошла ошибка");
            }
            LoadingScreen.IsVisible = false;
            EditScreen.IsEnabled = true;
        }
    }
}