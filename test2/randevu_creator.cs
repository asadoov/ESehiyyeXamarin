
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
using Newtonsoft.Json.Linq;
using Xamarin.Essentials;

namespace ESehiyye
{
    [Activity(Label = "randevu_creator")]
    public class randevu_creator : Activity
    {

        string date, time;
        // List<model.doctors> dr_data = new List<model.doctors>();
        List<model.users> user_data = new List<model.users>();
        DateTime today = DateTime.Today;
        AlertDialog.Builder alertDialog;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.randevu_creator);


            user_data = JsonConvert.DeserializeObject<List<model.users>>(Intent.GetStringExtra("data"));
            // dr_data = JsonConvert.DeserializeObject<List<model.doctors>>(Intent.GetStringExtra("dr_data"));

            FindViewById<TextView>(Resource.Id.toolbar_title).Text = Intent.GetStringExtra("dr_name");


            DatePickerDialog dateDialog = new DatePickerDialog(this, OnDateSet, today.Year, today.Month, today.Day);
            dateDialog.DatePicker.MinDate = today.Millisecond;
            dateDialog.Show();
            dateDialog.DismissEvent += (s, e) =>
             {
                 if (date == "")
                 {
                     dateDialog.Show();
                 }

                 // do whatever you need here, this will be called on
                 // dismiss (clicking on cancel button or outside of dialog)
             };
        }

        private void OnDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            if (Convert.ToInt32(Intent.GetStringExtra("dr_id")) > 0)
            {

                date = e.Date.ToString("yyyy-MM-dd");
                var dialog = new TimePickerDialog(this, listener, today.Hour, today.Minute - 1, true);
                dialog.Show();
            }
            else
            {
                alertDialog = new AlertDialog.Builder(this);
                alertDialog.SetTitle("Bildiriş");
                alertDialog.SetMessage("'Elektron səhiyyə' portalında qeydiyyatdan keçmədiyi üçün həkimin qəbuluna yazılmaq mümkün deil");
                alertDialog.Show();
            }

        }

        private async void listener(object sender, TimePickerDialog.TimeSetEventArgs e)
        {
            var timeSpan = new TimeSpan(e.HourOfDay, e.Minute, 0);

            time = timeSpan.ToString(@"hh\:mm");

            model.db_insert insert = new model.db_insert();
            //Toast.MakeText(this, Intent.GetStringExtra("dr_id"), ToastLength.Long).Show();
            if (Convert.ToInt32(Intent.GetStringExtra("dr_id")) > 0)
            {
                string status = await insert.randevu_insert(Preferences.Get("cypher1", "").ToString(),
                              Preferences.Get("cypher2", "").ToString(),
                              user_data[0].VESIQE_FIN,
                             date, time, Convert.ToInt32(Intent.GetStringExtra("dr_id")));

                dynamic d = JsonConvert.DeserializeObject(status);


                if (Convert.ToInt32(d[0]["RESULT"]) > 0)
                {
                    alertDialog = new AlertDialog.Builder(this);
                    alertDialog.SetTitle("Həkimə qeydiyyat tərtib edildi");
                    alertDialog.SetMessage("'Randevularım' bölməsinə keçid edərək qeydiyyatlarınızı redaktə edə və silə bilərsiniz");

                    //FindViewById<TextView>(Resource.Id.textView1).Text = "HƏKİMƏ QEYDİYYAT TƏRTİB EDİLDİ\nHəkimlə randevu tarixi: " + date + "\nHəkimlə randevu saatı: " + time + "\n'Randevularım' bölməsinə keçid edərək qeydiyyatlarınızı redaktə edə bilə və silə bilərsiniz ";
                    //Toast.MakeText(this, Convert.ToString(d[0]["RESULT"]), ToastLength.Long).Show();
                }
                else
                {
                    alertDialog = new AlertDialog.Builder(this);
                    alertDialog.SetTitle("Bildiriş");
                    alertDialog.SetMessage("'Elektron səhiyyə' portalında qeydiyyatdan keçmədiyi üçün həkimin qəbuluna yazılmaq mümkün deil");


                    //FindViewById<TextView>(Resource.Id.textView1).Text = "HALL HAZIRDA HƏKİMƏ QEYDİYYAT TƏRTİB ETMƏK MÜMKÜN DEİL";
                    //Toast.MakeText(this, "Bu hekimin qebuluna yazilmaq mumkun deil", ToastLength.Long).Show();
                }

            }
            else
            {
                alertDialog = new AlertDialog.Builder(this);
                alertDialog.SetTitle("Bildiriş");
                alertDialog.SetMessage("'Elektron səhiyyə' portalında qeydiyyatdan keçmədiyi üçün həkimin qəbuluna yazılmaq mümkün deil");


                //FindViewById<TextView>(Resource.Id.textView1).Text = "HALL HAZIRDA HƏKİMƏ QEYDİYYAT TƏRTİB ETMƏK MÜMKÜN DEİL";
                //Toast.MakeText(this, "Bu hekimin qebuluna yazilmaq mumkun deil", ToastLength.Long).Show();

            }

            alertDialog.SetNeutralButton("Qəbul et", delegate
            {

                Finish();
                Intent profile = new Intent(this, typeof(ProfileActivity));
                profile.PutExtra("data", JsonConvert.SerializeObject(user_data));
               
                StartActivity(profile);
            });
            alertDialog.SetNeutralButton("İmtina", delegate
            {

                Finish();
                Intent profile = new Intent(this, typeof(ProfileActivity));
                profile.PutExtra("data", JsonConvert.SerializeObject(user_data));
               
                StartActivity(profile);
            });
            alertDialog.SetNeutralButton("Posient haqqında", delegate
            {

                Finish();
                Intent profile = new Intent(this, typeof(ProfileActivity));
                profile.PutExtra("data", JsonConvert.SerializeObject(user_data));
                
                StartActivity(profile);
            });
            alertDialog.Show();

        }

        public override void OnBackPressed()
        {
            Finish();
            Intent profile = new Intent(this, typeof(ProfileActivity));
            profile.PutExtra("data", JsonConvert.SerializeObject(user_data));
            
            StartActivity(profile);
        }
    }
}
