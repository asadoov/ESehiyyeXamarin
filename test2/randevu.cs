
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
    [Activity(Label = "randevu")]
    public class randevu : Activity
    {
        ListView listView1;
        List<model.reservations> list = new List<model.reservations>();
        List<model.users> user_data = new List<model.users>();
        AlertDialog.Builder alertDialog;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.randevu);
            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Visible;

            user_data = JsonConvert.DeserializeObject<List<model.users>>(Intent.GetStringExtra("data"));
            model.db_select select = new model.db_select();

            list = await select.reservations(Preferences.Get("cypher1", "").ToString(), Preferences.Get("cypher2", "").ToString(), user_data[0].VESIQE_FIN);
            //Toast.MakeText(ApplicationContext, list[0].DocAdSoyad, ToastLength.Long).Show();

            listView1 = FindViewById<ListView>(Resource.Id.listView1);
            
             LanguageAdapter adapter = new LanguageAdapter(this, list);
            listView1.Adapter = adapter;
            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Gone;

            listView1.ItemClick += itemclick;
        }

        private void itemclick(object sender, AdapterView.ItemClickEventArgs e)
        {
            DateTime oDate = DateTime.ParseExact(list[e.Position].Tarix, "dd.MM.yyyy", null);
            alertDialog = new AlertDialog.Builder(this);
            alertDialog.SetTitle(oDate.ToString("dd MMMM", new System.Globalization.CultureInfo("az-Latn-AZ")) + " " + list[e.Position].Saat);
            alertDialog.SetMessage("📍 "+list[e.Position].MuesAd+"\n"+ "📞 "+list[e.Position].MuesTel+"\n"+ "⚕️ "+list[e.Position].DocAdSoyad);
            alertDialog.SetNeutralButton("Randevunu sil", delegate
            {
            });
            alertDialog.Show();
               
        }
    }
}
