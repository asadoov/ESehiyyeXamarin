
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
    [Activity(Label = "Regionlar")]
    public class Regionlar : Activity
    {
        private List<string> AD;
        List<model.regions_and_inst> regionlar = new List<model.regions_and_inst>();
        List<model.users> user_data = new List<model.users>();
        ArrayAdapter<string> mAdapter;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
           
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Regionlar);
           
                // update UI here
                FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Visible;
         
            
            user_data = JsonConvert.DeserializeObject<List<model.users>>(Intent.GetStringExtra("data"));
            model.db_select select = new model.db_select();
         
            regionlar = await select.regionlar(Preferences.Get("cypher2", "").ToString(), Preferences.Get("cypher2", "").ToString(), user_data[0].VESIQE_FIN);
            AD = new List<string>();

            foreach (var item in regionlar)
            {
                AD.Add(item.AD);
            }
             mAdapter= new ArrayAdapter<string>(this,Android.Resource.Layout.SimpleListItem1, AD);
            FindViewById<ListView>(Resource.Id.listView1).Adapter=mAdapter;
            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Gone;
            // Toast.MakeText(ApplicationContext, regionlar[1].AD , ToastLength.Long).Show();

            FindViewById<SearchView>(Resource.Id.searchView1).QueryTextChange += search;

            FindViewById<ListView>(Resource.Id.listView1).ItemClick += regionsClick;

              
        }

        private void search(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            mAdapter.Filter.InvokeFilter(e.NewText);
        }

        private void regionsClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var item = FindViewById<ListView>(Resource.Id.listView1).Adapter.GetItem(e.Position);
            foreach (var regions in regionlar)
            {
                if (item.ToString()==regions.AD)
                {
                    Finish();
                    Intent axtarish = new Intent(this, typeof(axtarish_param));
                    axtarish.PutExtra("data", JsonConvert.SerializeObject(user_data));
                  
                    axtarish.PutExtra("r_id",regions.ID.ToString());
                    axtarish.PutExtra("r_name", regions.AD);
                   
                    StartActivity(axtarish);
                    //Toast.MakeText(this, regions.ID.ToString(), ToastLength.Long).Show();
                }
            }
            
        }
    }
}
