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
    public partial class GuestPage : TabbedPage
    {
        public GuestPage()
        {
            InitializeComponent();
            
            Children.Add(new NewsPage());
            Children.Add(new ServicesPage());
        }
    }
}