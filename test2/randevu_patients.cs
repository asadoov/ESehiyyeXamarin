
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
    [Activity(Label = "randevus")]
    public class randevu_patients : Activity
    {
        ListView listView1;
        ObservableCollection<model.reservations_doctor> list = new ObservableCollection<model.reservations_doctor>();
        List<model.users> user_data = new List<model.users>();
        AlertDialog.Builder alertDialog;
        model.db_insert insert = new model.db_insert();
        model.db_select select = new model.db_select();
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.randevu_patients);
            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Visible;
            user_data = JsonConvert.DeserializeObject<List<model.users>>(Intent.GetStringExtra("data"));
           

            list = await select.reservations_doctor(Preferences.Get("cypher1", "").ToString(), Preferences.Get("cypher2", "").ToString(), user_data[0].VESIQE_FIN);
            //Toast.MakeText(ApplicationContext, list[0].DocAdSoyad, ToastLength.Long).Show();

            listView1 = FindViewById<ListView>(Resource.Id.listView1);
          
            randevu_patients_adapter adapter = new randevu_patients_adapter(list);
            listView1.Adapter = adapter;
            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Gone;
            listView1.ItemClick += itemclikck;
        }

        private void itemclikck(object sender, AdapterView.ItemClickEventArgs e)
        {
            alertDialog = new AlertDialog.Builder(this);
            alertDialog.SetTitle(list[e.Position].AdSoyad);
            // alertDialog.SetMessage("'Elektron səhiyyə' portalında qeydiyyatdan keçmədiyi üçün həkimin qəbuluna yazılmaq mümkün deil");
            if (list[e.Position].RandevuStatus!=3)
            {
                switch (list[e.Position].RandevuStatus)
                {

                    case 0:
                        alertDialog.SetNegativeButton("İmtina", delegate
                        {
                            EditText reason = new EditText(this);
                            reason.Hint = "Bura yazın";
                            alertDialog = new AlertDialog.Builder(this);
                            alertDialog.SetView(reason);
                            alertDialog.SetTitle("Səbəbi qeyd edin");


                            alertDialog.SetNeutralButton("Göndər", async delegate {
                                if (reason.Text != "")
                                {
                                    string status = await insert.randevu_ch_status(Preferences.Get("cypher1", ""),
                                    Preferences.Get("cypher2", ""),
                                    user_data[0].VESIQE_FIN, list[e.Position].RandevuId, 3, reason.Text);
                                    alertDialog = new AlertDialog.Builder(this);
                                    alertDialog.SetMessage("⚠️ Randevudan imtina edildi");


                                    alertDialog.Show();
                                    list = await select.reservations_doctor(Preferences.Get("cypher1", "").ToString(), Preferences.Get("cypher2", "").ToString(), user_data[0].VESIQE_FIN);
                                    //Toast.MakeText(ApplicationContext, list[0].DocAdSoyad, ToastLength.Long).Show();

                                    listView1 = FindViewById<ListView>(Resource.Id.listView1);
                                    randevu_patients_adapter adapter = new randevu_patients_adapter(list);
                                    listView1.Adapter = adapter;
                                }

                            });
                            alertDialog.Show();
                        });
                        alertDialog.SetPositiveButton("Posient haqqında", delegate
                        {

                            alertDialog.Dispose();
                        });
                        alertDialog.SetNeutralButton("Qəbul et", async delegate
                        {
                            string status = await insert.randevu_ch_status(Preferences.Get("cypher1", ""),
                                 Preferences.Get("cypher2", ""),
                                  user_data[0].VESIQE_FIN, list[e.Position].RandevuId, 2, "");
                            alertDialog = new AlertDialog.Builder(this);
                            alertDialog.SetMessage("✔️ Randevu qəbul olundu!");
                            alertDialog.Show();
                            list = await select.reservations_doctor(Preferences.Get("cypher1", "").ToString(), Preferences.Get("cypher2", "").ToString(), user_data[0].VESIQE_FIN);
                            //Toast.MakeText(ApplicationContext, list[0].DocAdSoyad, ToastLength.Long).Show();

                            listView1 = FindViewById<ListView>(Resource.Id.listView1);
                            randevu_patients_adapter adapter = new randevu_patients_adapter( list);
                            listView1.Adapter = adapter;

                        });
                        break;
                    case 1:
                        break;
                    case 2:

                        alertDialog.SetNegativeButton("İmtina", delegate
                        {
                            EditText reason = new EditText(this);
                            reason.Hint = "Bura yazın";
                            alertDialog = new AlertDialog.Builder(this);
                            alertDialog.SetView(reason);
                            alertDialog.SetTitle("Səbəbi qeyd edin");


                            alertDialog.SetNeutralButton("Göndər", async delegate {
                                if (reason.Text != "")
                                {
                                    string status = await insert.randevu_ch_status(Preferences.Get("cypher1", ""),
                                    Preferences.Get("cypher2", ""),
                                    user_data[0].VESIQE_FIN, list[e.Position].RandevuId, 3, reason.Text);
                                    alertDialog = new AlertDialog.Builder(this);
                                    alertDialog.SetMessage("⚠️ Randevudan imtina edildi");


                                    alertDialog.Show();
                                    list = await select.reservations_doctor(Preferences.Get("cypher1", "").ToString(), Preferences.Get("cypher2", "").ToString(),user_data[0].VESIQE_FIN);
                                    //Toast.MakeText(ApplicationContext, list[0].DocAdSoyad, ToastLength.Long).Show();

                                    listView1 = FindViewById<ListView>(Resource.Id.listView1);
                                    randevu_patients_adapter adapter = new randevu_patients_adapter( list);
                                    listView1.Adapter = adapter;
                                }

                            });
                            alertDialog.Show();
                        });
                        alertDialog.SetPositiveButton("Posient haqqında", delegate
                        {

                            alertDialog.Dispose();
                        });
                        break;
                    case 3:
                        break;
                }
             
               
                alertDialog.Show();



            }
           
        
          
        }
    }
}
