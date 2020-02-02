
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    [Activity(Label = "ExidmetActivity")]
    public class ExidmetActivity : Activity
    {
        List<string> info;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.elektron_xidmetler);

            info = new List<string>();
            info.AddRange(new string[] {"Dərman vasitələri haqqında məlumat verilməsi",
           "İmmuniprofilaktika üzrə məlumatın verilməsi",
                "Tibb müəssisələri barədə məlumatların verilməsi",
                "Xəstəliklərin Beynəlxalq Təsnifatı"});
            elektron_xidmetler_adapter adapter = new elektron_xidmetler_adapter(info);

            FindViewById<ListView>(Resource.Id.listView1).Adapter = adapter;
            FindViewById<ListView>(Resource.Id.listView1).ItemClick += item_click;

            var bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            bottomNavigation.SelectedItemId = Resource.Id.elektron_xidmet;
            bottomNavigation.NavigationItemSelected += (s, e) =>
            {
                switch (e.Item.ItemId)
                {
                    case Resource.Id.profile:
                        Finish();
                        Intent profile = new Intent(this, typeof(ProfileActivity));
                        StartActivity(profile);
                        break;
                    case Resource.Id.emergency:
                        Finish();
                        Intent emergency = new Intent(this, typeof(emergency));
                        StartActivity(emergency);
                        break;
                }
            };
        }

        private void item_click(object sender, AdapterView.ItemClickEventArgs e)
        {
            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Visible;
            switch (e.Position)
            {
                case 0:

                    Intent drugs = new Intent(this, typeof(drugs));

                    StartActivity(drugs);
                    break;
                case 1:
                    Intent immunity = new Intent(this, typeof(immunity));

                    StartActivity(immunity);
                    break;
                case 2:
                    Intent institutions_info = new Intent(this, typeof(institutions_info));

                    StartActivity(institutions_info);
                    break;
            }
            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Gone;
        }

        public override void OnBackPressed()
        {
            FinishAffinity();
        }
    }
}