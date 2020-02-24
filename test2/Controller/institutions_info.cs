using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Xamarin.Essentials;
using AlertDialog = Android.App.AlertDialog;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;

namespace ESehiyye
{
    [Activity(Label = "institutions_info")]
    public class institutions_info : AppCompatActivity
    {
        ListView listView1;
        ObservableCollection<model.institutions_info> list = new ObservableCollection<model.institutions_info>();
        ArrayAdapter<string> mAdapter;
        private List<string> AD;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.institutions_info);



            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
          
            SetSupportActionBar(toolbar);
            
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
          
       
            // Create your application here
            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Visible;

           
            model.db_select select = new model.db_select();

            list = await select.get_institutions(Preferences.Get("cypher1", "").ToString(), Preferences.Get("cypher2", "").ToString());
            //Toast.MakeText(ApplicationContext, list[0].DocAdSoyad, ToastLength.Long).Show();

            listView1 = FindViewById<ListView>(Resource.Id.listView1);
            FindViewById<SearchView>(Resource.Id.searchView1).QueryTextChange += search;
            AD = new List<string>();

            foreach (var item in list)
            {
                AD.Add(item.AD);
            }
            mAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, AD);
            if (!mAdapter.IsEmpty)
            {

                FindViewById<ListView>(Resource.Id.listView1).Adapter = mAdapter;
            }
            else
            {
                AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                alertDialog.SetTitle("Bildiriş");
                alertDialog.SetMessage("Xəta baş verdi");
                alertDialog.SetNeutralButton("Geriyə", delegate {
                    alertDialog.Dispose();

                });
                alertDialog.Show();

            }
           
            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Gone;

 

        }
        private void search(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            mAdapter.Filter.InvokeFilter(e.NewText);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:

                    OnBackPressed();
                    return true;
            }
            return true;
        }
    }
}