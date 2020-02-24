
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;

using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Xamarin.Essentials;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;

namespace ESehiyye
{
    [Activity(Label = "ProfileActivity")]
    public class ProfileActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.ProfileActivity);
            if (Preferences.Get("user_data", "") != "")
            {


                var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
                SetSupportActionBar(toolbar);

                SupportActionBar.SetDisplayHomeAsUpEnabled(false);
                List<model.users> user_data = new List<model.users>();
                user_data = JsonConvert.DeserializeObject<List<model.users>>(Preferences.Get("user_data", ""));
                if (user_data[0].STATUS != "tibbkadr")
                {
                    FindViewById<Button>(Resource.Id.snsk).Visibility = ViewStates.Gone;
                    FindViewById<Button>(Resource.Id.dtt).Visibility = ViewStates.Gone;
                }
                //if (user_data[0].STATUS == "general")
                //{



                //}
                // Convert base 64 string to byte[]
                if (!string.IsNullOrEmpty(user_data[0].PHOTO_BASE64))
                {
                    byte[] imageAsBytes = Base64.Decode(user_data[0].PHOTO_BASE64, Base64Flags.Default);
                    Android.Graphics.Bitmap image = BitmapFactory.DecodeByteArray(imageAsBytes, 0, imageAsBytes.Length);
                    FindViewById<ImageView>(Resource.Id.user_image).SetImageBitmap(image);
                }
         
                FindViewById<TextView>(Resource.Id.user_name).Text = user_data[0].NAME;

                var collapsingToolbar = FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing_toolbar);
                collapsingToolbar.Activated = true;
                collapsingToolbar.SetExpandedTitleColor(Android.Graphics.Color.ParseColor("#00FFFFFF"));
                collapsingToolbar.Title = user_data[0].NAME;


                FindViewById<TextView>(Resource.Id.user_details).Text = "Boy: " + user_data[0].BOY + " SM, Yaş: " + user_data[0].YASH + ", Qan: " + user_data[0].QAN;



                var bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
                bottomNavigation.SelectedItemId = Resource.Id.profile;

                bottomNavigation.NavigationItemSelected += (s, e) =>
                 {
                     switch (e.Item.ItemId)
                     {
                         case Resource.Id.feedback:
                            // Finish();
                             FindViewById<LinearLayout>(Resource.Id.feedback).Visibility = ViewStates.Visible;
                             //Intent feedback = new Intent(this, typeof());
                             //StartActivity(feedback);
                             break;
                         case Resource.Id.news:
                           //  Finish();
                             //Intent news = new Intent(this, typeof(newsActivity));
                             //StartActivity(news);
                             break;
                     }
                 };
                //Servislerin click eventleri
                //FindViewById<Button>(Resource.Id.button1).Click += delegate
                //{
                //    Intent randevu_patients = new Intent(this, typeof(randevu_patients));
                //    randevu_patients.PutExtra("data", JsonConvert.SerializeObject(user_data));

                   
                //    StartActivity(randevu_patients);

                //};
                //FindViewById<Button>(Resource.Id.button2).Click += delegate
                //{
                //    Intent posient_details_start = new Intent(this, typeof(posient_details_start));
                   
                //    StartActivity(posient_details_start);

                //};
                //FindViewById<Button>(Resource.Id.button3).Click += delegate
                //{
                //    Intent axtarish = new Intent(this, typeof(StartSearch));
                //    axtarish.PutExtra("data", JsonConvert.SerializeObject(user_data));
          
                //    StartActivity(axtarish);

                //};
                //FindViewById<Button>(Resource.Id.button4).Click += delegate
                //{
                //    Intent randevu = new Intent(this, typeof(randevu));
                //    randevu.PutExtra("data", JsonConvert.SerializeObject(user_data));
                   
                //    StartActivity(randevu);

                //};
            }
            else
            {

            }
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.profile_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId==Resource.Id.settings)
            {
                Intent settings = new Intent(this, typeof(settings));
                StartActivity(settings);
            }
            
            return base.OnOptionsItemSelected(item);
        }
        public override void OnBackPressed()
        {
            FinishAffinity();
        }


        [Java.Interop.Export("immunity")]
        public void immunity(View v)
        {

            Intent immunity = new Intent(this, typeof(immunity));

            StartActivity(immunity);
          

        }
        [Java.Interop.Export("drugs")]
        public void drugs(View v)
        {

            Intent drugs = new Intent(this, typeof(drugs));

            StartActivity(drugs);


        }

    }
}
