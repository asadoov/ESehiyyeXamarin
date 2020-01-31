
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    [Activity(Label = "posient_details")]
    public class posient_details : Activity
    {
        ListView listView1;
        ObservableCollection<model.posient_details> list = new ObservableCollection<model.posient_details>();
        List<model.users> user_data = new List<model.users>();
        AlertDialog.Builder alertDialog;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.posient_details);
            // Create your application here
            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Visible;

            user_data = JsonConvert.DeserializeObject<List<model.users>>(Preferences.Get("user_data", ""));
            model.db_select select = new model.db_select();

            list = await select.posient_details(Preferences.Get("cypher1", "").ToString(), Preferences.Get("cypher2", "").ToString(), user_data[0].VESIQE_FIN, Intent.GetStringExtra("patient_fin"), Intent.GetStringExtra("unique_id"), Intent.GetStringExtra("name"), Intent.GetStringExtra("surname"), Intent.GetStringExtra("dad_name"));
            // Toast.MakeText(ApplicationContext, list[0].ToString(), ToastLength.Long).Show();

            listView1 = FindViewById<ListView>(Resource.Id.listView1);

            patients_detail_adapter adapter = new patients_detail_adapter(list);
            listView1.Adapter = adapter;
            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Gone;

            listView1.ItemClick += itemclick;
        }

        private void itemclick(object sender, AdapterView.ItemClickEventArgs e)
        {
            model.db_insert insert = new model.db_insert();
            alertDialog = new AlertDialog.Builder(this);
            
            alertDialog.SetMessage("Posientin məlumatlarına baxmaq üçün, posientin razılığı tələb olunur. Posiente bildiriş göndəriləcək. Göndərilsin?");
            alertDialog.SetNegativeButton("Xeyr", delegate
            {
                alertDialog.Dispose();
            });
            alertDialog.SetPositiveButton("Bəli", async delegate
            {
                string status = await insert.send_sms(Preferences.Get("cypher1", "").ToString(), Preferences.Get("cypher2", "").ToString(), user_data[0].VESIQE_FIN, list[e.Position].Unikalkod.ToString());

                dynamic d = JsonConvert.DeserializeObject(status);
                if (Convert.ToInt32(d[0]["SEND_SMS"]) == 0)
                {
                    Intent code_check = new Intent(this, typeof(verification_code_check));
                    code_check.PutExtra("patient_id", list[e.Position].Unikalkod);
                    StartActivity(code_check);
                }
                else
                {
                    alertDialog = new AlertDialog.Builder(this);
                    alertDialog.SetTitle("Bildiriş");
                    alertDialog.SetMessage("Sms göndərmək mümkün olmadı, biraz sonra yenidən cəhd edin");


                  
                }
              
            });
            alertDialog.Show();
        }
    }
}
