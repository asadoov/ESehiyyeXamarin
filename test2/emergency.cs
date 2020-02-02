
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;

namespace ESehiyye
{
    [Activity(Label = "emergency")]
    public class emergency : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_emergency);

            var bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            bottomNavigation.SelectedItemId = Resource.Id.emergency;
            bottomNavigation.NavigationItemSelected += (s, e) =>
            {
                switch (e.Item.ItemId)
                {
                    case Resource.Id.profile:
                        Finish();
                        Intent profile = new Intent(this, typeof(ProfileActivity));
                        StartActivity(profile);
                        break;
                    case Resource.Id.elektron_xidmet:
                        Finish();
                        Intent exidmet = new Intent(this, typeof(ExidmetActivity));
                        StartActivity(exidmet);
                        break;
                }
            };
        }

        public override void OnBackPressed()
        {
            FinishAffinity();
        }
    }
}
