
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
namespace ESehiyye
{
    [Activity(Label = "StartSearch")]
    public class StartSearch : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.StartSearch);
            FindViewById<Button>(Resource.Id.button1).Click += delegate
            {
                Intent axtarish_param = new Intent(this, typeof(axtarish_param));
                axtarish_param.PutExtra("data", Intent.GetStringExtra("data"));
        
                StartActivity(axtarish_param);

            };
        }
    }
}
