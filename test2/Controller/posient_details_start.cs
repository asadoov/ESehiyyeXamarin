
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
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace ESehiyye
{
    [Activity(Label = "posient_start_search")]
    public class posient_details_start : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.posient_details_start);
            FindViewById<Button>(Resource.Id.button1).Click += delegate
            {
                Intent patient_details_params = new Intent(this, typeof(posient_details_params));

                StartActivity(patient_details_params);

            };
        }
    }
}
