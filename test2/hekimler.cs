
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
    [Activity(Label = "hekimler")]
    public class hekimler : Activity
    {
        private List<string> AD;
        List<model.doctors> doctors = new List<model.doctors>();
        List<model.users> user_data = new List<model.users>();
        ArrayAdapter<string> mAdapter;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.doctors);
            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Visible;


            user_data = JsonConvert.DeserializeObject<List<model.users>>(Intent.GetStringExtra("data"));
            model.db_select select = new model.db_select();

            doctors = await select.doctors(Preferences.Get("cypher1", "").ToString(), Preferences.Get("cypher2", "").ToString(), user_data[0].VESIQE_FIN,
                Convert.ToInt32(Intent.GetStringExtra("r_id")),Convert.ToInt32(Intent.GetStringExtra("m_id")), Intent.GetStringExtra("ad"), Intent.GetStringExtra("soyad"), Convert.ToInt32(Intent.GetStringExtra("ixtisas_id")));
            AD = new List<string>();

            foreach (var item in doctors)
            {
                AD.Add(item.AD_SOYAD);
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
                alertDialog.SetMessage("Axtarış üzrə heç bir nəticə tapilmadı");
                alertDialog.SetNeutralButton("Geriyə", delegate {
                    if (Convert.ToInt32(Intent.GetStringExtra("ixtisas_id"))>0)
                    {

                        Intent vezifeler = new Intent(this, typeof(vezifeler));
                        vezifeler.PutExtra("data", Intent.GetStringExtra("data"));
                
                        vezifeler.PutExtra("r_id", Intent.GetStringExtra("r_id"));
                        vezifeler.PutExtra("m_id", Intent.GetStringExtra("m_id"));
                        StartActivity(vezifeler);
                    }
                    else
                    {

                        Intent axtarish_param = new Intent(this, typeof(axtarish_param));
                        axtarish_param.PutExtra("data", Intent.GetStringExtra("data"));
                        
                        axtarish_param.PutExtra("r_id", Intent.GetStringExtra("r_id"));
                        axtarish_param.PutExtra("m_id", Intent.GetStringExtra("m_id"));
                        StartActivity(axtarish_param);
                    }
           
                });
                alertDialog.Show();
               
            }
           
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
            foreach (var doctor in doctors)
            {
                if (item.ToString() == doctor.AD_SOYAD)
                {
              
                    Intent axtarish = new Intent(this, typeof(randevu_creator));
                    axtarish.PutExtra("data", JsonConvert.SerializeObject(user_data));
                
                    axtarish.PutExtra("dr_id", doctor.USERID.ToString());
                    axtarish.PutExtra("dr_name", doctor.AD_SOYAD);

                    StartActivity(axtarish);
                   //Toast.MakeText(this, doctor.USERID.ToString(), ToastLength.Long).Show();
                }
            }
        }
    }
}
