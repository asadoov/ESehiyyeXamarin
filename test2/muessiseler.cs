
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
    [Activity(Label = "muessiseler")]
    public class muessiseler : Activity
    {
        private List<string> AD;
        List<model.regions_and_inst> mues = new List<model.regions_and_inst>();
        List<model.users> user_data = new List<model.users>();
        ArrayAdapter<string> mAdapter;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Muessiseler);
            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Visible;


            user_data = JsonConvert.DeserializeObject<List<model.users>>(Intent.GetStringExtra("data"));
            model.db_select select = new model.db_select();

            mues = await select.Institutions(Preferences.Get("cypher1", "").ToString(), Preferences.Get("cypher2", "").ToString(), user_data[0].VESIQE_FIN, Convert.ToInt32(Intent.GetStringExtra("r_id")));
            AD = new List<string>();

            foreach (var item in mues)
            {
                AD.Add(item.AD);
            }
       mAdapter  = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, AD);
            FindViewById<ListView>(Resource.Id.listView1).Adapter = mAdapter;
            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Gone;
            // Toast.MakeText(ApplicationContext, regionlar[1].AD , ToastLength.Long).Show();
            FindViewById<SearchView>(Resource.Id.searchView1).QueryTextChange += search;
            FindViewById<ListView>(Resource.Id.listView1).ItemClick += instClick;
        }

        private void search(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            mAdapter.Filter.InvokeFilter(e.NewText);
        }

        private void instClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var item = FindViewById<ListView>(Resource.Id.listView1).Adapter.GetItem(e.Position);
            foreach (var muessise in mues)
            {
                if (item.ToString() == muessise.AD)
                {
                    Finish();
                    Intent axtarish = new Intent(this, typeof(axtarish_param));
                    axtarish.PutExtra("data", JsonConvert.SerializeObject(user_data));
                    axtarish.PutExtra("pass", Intent.GetStringExtra("pass"));
                    axtarish.PutExtra("r_id", Intent.GetStringExtra("r_id"));
                    axtarish.PutExtra("r_name", Intent.GetStringExtra("r_name"));
                    axtarish.PutExtra("m_name", muessise.AD);
                    axtarish.PutExtra("m_id", muessise.ID.ToString());
                    StartActivity(axtarish);
                    //Toast.MakeText(this, regions.ID.ToString(), ToastLength.Long).Show();
                }
            }
        }
    }
}
