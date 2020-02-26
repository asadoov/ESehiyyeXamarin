
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;

using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Xamarin.Essentials;
using ESehiyye.Controller;
using ESehiyye.model;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using System;

namespace ESehiyye
{
    [Activity(Label = "ProfileActivity")]
    public class ProfileActivity : AppCompatActivity
    {
        ObservableCollection<model.NewsStruct> newsList = new ObservableCollection<model.NewsStruct>();
        ObservableCollection<model.NewsStruct> filteredNewsList = new ObservableCollection<model.NewsStruct>();
        NewsAdapter newsAdapter;
        model.db_select select = new model.db_select();
        //bool newsClicked = false;
        Android.App.AlertDialog.Builder alertDialog;
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

                bottomNavigation.NavigationItemSelected += async (s, e) =>
                 {
                     switch (e.Item.ItemId)
                     {
                         case Resource.Id.feedback:
                            // Finish();
                             FindViewById<LinearLayout>(Resource.Id.feedback).Visibility = ViewStates.Visible;
                             FindViewById<LinearLayout>(Resource.Id.news).Visibility = ViewStates.Gone;
                             FindViewById<AppBarLayout>(Resource.Id.appbar).Visibility = ViewStates.Gone;
                             FindViewById<NestedScrollView>(Resource.Id.profileScroll).Visibility = ViewStates.Gone;

                             //Intent feedback = new Intent(this, typeof());
                             //StartActivity(feedback);
                             break;
                         case Resource.Id.news:


                             FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Visible;
                             FindViewById<LinearLayout>(Resource.Id.news).Visibility = ViewStates.Visible;
                             FindViewById<TextView>(Resource.Id.toolbarTitle).Text = "Xəbərlər";
                             FindViewById<LinearLayout>(Resource.Id.feedback).Visibility = ViewStates.Gone;
                             FindViewById<AppBarLayout>(Resource.Id.appbar).Visibility = ViewStates.Gone;
                             FindViewById<NestedScrollView>(Resource.Id.profileScroll).Visibility = ViewStates.Gone;

                             FindViewById<SearchView>(Resource.Id.newsSearch).QueryTextChange += newsSearch;



                             newsList = await select.getNews(Preferences.Get("cypher1", "").ToString(), Preferences.Get("cypher2", "").ToString());
                                 if (newsList.Count > 0)
                                 {


                                   newsAdapter = new NewsAdapter(newsList);
                                     FindViewById<ListView>(Resource.Id.newsList).Adapter = newsAdapter;
                                 FindViewById<ListView>(Resource.Id.newsList).ItemClick += newsClicked;
                                    // newsClicked = true;
                                 }
                                 else
                                 {
                                     alertDialog = new Android.App.AlertDialog.Builder(this);
                                     alertDialog.SetTitle("Bildiriş");
                                     alertDialog.SetMessage("Xəbərləri yükləmək mümkün olmadı");
                                     //alertDialog.SetPositiveButton("Tamam", delegate
                                     //{
                                     //    alertDialog.Dispose();
                                     //});
                                     alertDialog.Show();
                                 }
                             
                             FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Gone;
                             break;
                         case Resource.Id.profile:
                             FindViewById<AppBarLayout>(Resource.Id.appbar).Visibility = ViewStates.Visible;
                             FindViewById<NestedScrollView>(Resource.Id.profileScroll).Visibility = ViewStates.Visible;
                             FindViewById<LinearLayout>(Resource.Id.news).Visibility = ViewStates.Gone;
                             FindViewById<LinearLayout>(Resource.Id.feedback).Visibility = ViewStates.Gone;
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

        private void newsClicked(object sender, AdapterView.ItemClickEventArgs e)
        {
           
            FindViewById<SearchView>(Resource.Id.newsSearch).Visibility=ViewStates.Gone;
            FindViewById<ListView>(Resource.Id.newsList).Visibility = ViewStates.Gone;
            FindViewById<TextView>(Resource.Id.newsDetailedDescription).Visibility = ViewStates.Visible;
            FindViewById<ImageButton>(Resource.Id.backBtn).Visibility = ViewStates.Visible;
            if (filteredNewsList.Count>0)
            {
                FindViewById<TextView>(Resource.Id.toolbarTitle).Text = filteredNewsList[e.Position].NAME;
                FindViewById<TextView>(Resource.Id.newsDetailedDescription).Text = filteredNewsList[e.Position].TEXT;
            }
            else
            {
                FindViewById<TextView>(Resource.Id.toolbarTitle).Text = newsList[e.Position].NAME;
                FindViewById<TextView>(Resource.Id.newsDetailedDescription).Text = newsList[e.Position].TEXT;
            }
           


        }
        [Java.Interop.Export("backClicked")]
        public void backClicked(View v)
        {
            FindViewById<SearchView>(Resource.Id.newsSearch).Visibility = ViewStates.Visible;
            FindViewById<ListView>(Resource.Id.newsList).Visibility = ViewStates.Visible;
            FindViewById<TextView>(Resource.Id.newsDetailedDescription).Visibility = ViewStates.Gone;
            FindViewById<ImageButton>(Resource.Id.backBtn).Visibility = ViewStates.Gone;
            FindViewById<TextView>(Resource.Id.toolbarTitle).Text = "Xəbərlər";
            FindViewById<TextView>(Resource.Id.newsDetailedDescription).Text = "";



        }
        private void newsSearch(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            var searchText = e.NewText;
            switch (searchText)
            {
                case "":
                    filteredNewsList.Clear();
               newsAdapter = new NewsAdapter(newsList);
                    break;
                default:
                    filteredNewsList.Clear();
                    foreach (model.NewsStruct item in newsList)
                    {
                        if (item.NAME.ToLower().Contains(searchText.ToLower()))
                        {
                            filteredNewsList.Add(item);
                        }
                    }

                    newsAdapter = new NewsAdapter(filteredNewsList);

                    break;
            }
            FindViewById<ListView>(Resource.Id.newsList).Adapter = newsAdapter;


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
        [Java.Interop.Export("sendFeedback")]
        public void sendFeedback(View v)
        {

            string feedbackTxt = FindViewById<TextView>(Resource.Id.feedbackTxt).Text;
            if (feedbackTxt.Length > 5 && !string.IsNullOrEmpty(feedbackTxt))
            {

            }
            else
            {
                alertDialog = new Android.App.AlertDialog.Builder(this);
                alertDialog.SetTitle("Bildiriş");
                alertDialog.SetMessage("Zəhmət olmasa müracitinizi daxil edin");
                //alertDialog.SetPositiveButton("Tamam", delegate
                //{
                //    alertDialog.Dispose();
                //});
                alertDialog.Show();
            }


        }


    }
}
