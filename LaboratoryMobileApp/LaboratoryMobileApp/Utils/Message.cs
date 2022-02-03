using Android.Widget;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratoryMobileApp.Utils
{
    internal static class Message
    {
        public static void ShowShort(string message) => Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        public static void ShowLong(string message) => Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
    }
}
