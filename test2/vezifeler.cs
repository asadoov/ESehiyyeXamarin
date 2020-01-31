
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
    [Activity(Label = "ixtisaslar")]
    public class vezifeler : Activity
    {
        private List<string> AD;
        List<model.vezifeler> ixtisaslar = new List<model.vezifeler>();
        List<model.doctors> doctors = new List<model.doctors>();

        List<model.users> user_data = new List<model.users>();
        ArrayAdapter<string> mAdapter;
   
        
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
          
            // Create your application here
            SetContentView(Resource.Layout.vezifeler);
            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Visible;


            user_data = JsonConvert.DeserializeObject<List<model.users>>(Intent.GetStringExtra("data"));
            model.db_select select = new model.db_select();
            doctors = await select.doctors(Preferences.Get("cypher1", "").ToString(), Preferences.Get("cypher2", "").ToString(), user_data[0].VESIQE_FIN,
               Convert.ToInt32(Intent.GetStringExtra("r_id")), Convert.ToInt32(Intent.GetStringExtra("m_id")), "", "", 0);
            // ixtisaslar = await select.vezifeler(user_data[0].EMAIL, Intent.GetStringExtra("pass"), user_data[0].VESIQE_FIN);

            AD = new List<string>();
            if (doctors.Count()>0)
            {
                AD.Add("Bütün vəzifələr");
            }
            else
            {
                AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                alertDialog.SetTitle("Bildiriş");
                alertDialog.SetMessage("Axtarış üzrə heç bir nəticə tapilmadı");
                alertDialog.SetNeutralButton("Geriyə", delegate {
                   
                        Intent axtarish_param = new Intent(this, typeof(axtarish_param));
                        axtarish_param.PutExtra("data", Intent.GetStringExtra("data"));
                       
                    axtarish_param.PutExtra("r_id", Intent.GetStringExtra("r_id"));
                    axtarish_param.PutExtra("m_id", Intent.GetStringExtra("m_id"));
                    StartActivity(axtarish_param);
                    
                });
                alertDialog.Show();
            }      
          
            foreach (var inst_item in doctors)
                {
                
                //Toast.MakeText(ApplicationContext, inst_item.MUES_ID.ToString(), ToastLength.Long).Show();
                if (AD.Count() == 0)
                    {
                        AD.Add(inst_item.VEZIFE);
                    }
                    else
                    {
                        if (AD.Contains(inst_item.VEZIFE)==false)
                        {
                            AD.Add(inst_item.VEZIFE);
                        }
                    }
                }
            

          

            
        

            /*

            foreach (var item in ixtisaslar)
            {
                AD.Add(item.AD);
            }
            */
            mAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, AD);
            FindViewById<ListView>(Resource.Id.listView1).Adapter = mAdapter;
            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Gone;
            // Toast.MakeText(ApplicationContext, regionlar[1].AD , ToastLength.Long).Show();
            FindViewById<SearchView>(Resource.Id.searchView1).QueryTextChange += search;
            FindViewById<ListView>(Resource.Id.listView1).ItemClick += instClick;
        }

        private void instClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var item = FindViewById<ListView>(Resource.Id.listView1).Adapter.GetItem(e.Position);
            foreach (var ixtisas in doctors)
            {
                if (item.ToString() == ixtisas.VEZIFE)
                {
                    Finish();
                    Intent hekimler = new Intent(this, typeof(hekimler));
                    hekimler.PutExtra("data", JsonConvert.SerializeObject(user_data));
                 
                    hekimler.PutExtra("r_id", Intent.GetStringExtra("r_id"));
                    hekimler.PutExtra("m_id", Intent.GetStringExtra("m_id"));
                    hekimler.PutExtra("ixtisas_id", ixtisas.VEZIFE_ID.ToString());
                    StartActivity(hekimler);
                    //Toast.MakeText(this, regions.ID.ToString(), ToastLength.Long).Show();
                }
                if (item.ToString() == "Bütün vəzifələr")
                {
                    Finish();
                    Intent hekimler = new Intent(this, typeof(hekimler));
                    hekimler.PutExtra("data", JsonConvert.SerializeObject(user_data));
                
                    hekimler.PutExtra("r_id", Intent.GetStringExtra("r_id"));
                    hekimler.PutExtra("m_id", Intent.GetStringExtra("m_id"));
                    hekimler.PutExtra("ixtisas_id", 0);
                    StartActivity(hekimler);
                    //Toast.MakeText(this, regions.ID.ToString(), ToastLength.Long).Show();
                }
            }
        }

        private void search(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            mAdapter.Filter.InvokeFilter(e.NewText);
        }
    }
}
