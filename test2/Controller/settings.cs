
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace ESehiyye
{
    [Activity(Label = "settings")]
    public class settings : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.settings);
            FindViewById<TextView>(Resource.Id.toolbarTitle).Text = "Parametrlər";
            FindViewById<ImageButton>(Resource.Id.backBtn).Visibility = ViewStates.Visible;
            FindViewById<Button>(Resource.Id.log_out).Visibility = ViewStates.Visible;

        
            FindViewById<Button>(Resource.Id.log_out).Click += delegate
            {
                FinishAffinity();
                Preferences.Set("cypher1", "");
                Preferences.Get("cypher2", "");
                Preferences.Set("user_data", "");
                Intent main = new Intent(this, typeof(MainActivity));                
                StartActivity(main);
          
            };
        }
        [Java.Interop.Export("backClicked")]
        public void backClicked(View v)
        {


            OnBackPressed();
            //Toast.MakeText(ApplicationContext, "esdasad", ToastLength.Long).Show();

        }
    }
}
