using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ssuarezS5.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly:Xamarin.Forms.Dependency(typeof(MensajeAndroid))]

namespace ssuarezS5.Droid
{
    public class MensajeAndroid : InterfaceToast
    {
        public void longMessage(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void shortMessage(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}