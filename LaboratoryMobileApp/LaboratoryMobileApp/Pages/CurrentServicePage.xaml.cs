using LaboratoryMobileApp.Models;
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
    public partial class CurrentServicePage : ContentPage
    {
        public CurrentServicePage(Service service)
        {
            InitializeComponent();
            BindingContext = service;
        }
    }
}