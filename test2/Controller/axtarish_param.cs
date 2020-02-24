
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Views;
using Android.Widget;
using AlertDialog = Android.App.AlertDialog;
namespace ESehiyye
{
    [Activity(Label = "axtarish_param")]
    public class axtarish_param : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.axtarish_param);
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar2);
            SetSupportActionBar(toolbar);


            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            if (!string.IsNullOrWhiteSpace(Intent.GetStringExtra("r_id")))
            {
                FindViewById<Button>(Resource.Id.button2).Enabled = true;
                // Toast.MakeText(this, Intent.GetStringExtra("m_id"), ToastLength.Long).Show();
                FindViewById<Button>(Resource.Id.button1).Text = Intent.GetStringExtra("r_name");
            }

            if (!string.IsNullOrWhiteSpace(Intent.GetStringExtra("m_id")))
            {
                FindViewById<Button>(Resource.Id.button2).Enabled = true;
                // Toast.MakeText(this, Intent.GetStringExtra("r_id")+" "+Intent.GetStringExtra("m_id"), ToastLength.Long).Show();

                FindViewById<Button>(Resource.Id.button1).Text = Intent.GetStringExtra("r_name");
                FindViewById<Button>(Resource.Id.button2).Text = Intent.GetStringExtra("m_name");


            }
            FindViewById<Button>(Resource.Id.button1).Click += delegate
            {
                //Выбор города

                //FindViewById<Button>(Resource.Id.button2).Text = "Tibb müəssisəsini daxil edin...";
                Finish();
                Intent regionlar = new Intent(this, typeof(Regionlar));
                regionlar.PutExtra("data", Intent.GetStringExtra("data"));
                
                StartActivity(regionlar);

            };
            FindViewById<Button>(Resource.Id.button2).Click += delegate
            {
                //Выбор региона

                Finish();
                Intent mues = new Intent(this, typeof(muessiseler));
                mues.PutExtra("data", Intent.GetStringExtra("data"));
              
                mues.PutExtra("r_id", Intent.GetStringExtra("r_id"));
                mues.PutExtra("r_name", Intent.GetStringExtra("r_name"));
                StartActivity(mues);

            };
            FindViewById<Button>(Resource.Id.button3).Click += delegate
            {
                //Кнопка поиска
                if (FindViewById<EditText>(Resource.Id.editText1).Text != "" || FindViewById<EditText>(Resource.Id.editText2).Text != "")

                {
                    Intent hekimler = new Intent(this, typeof(hekimler));
                    hekimler.PutExtra("data", Intent.GetStringExtra("data"));
                   
                    hekimler.PutExtra("r_id", Intent.GetStringExtra("r_id"));
                    hekimler.PutExtra("m_id", Intent.GetStringExtra("m_id"));
                    hekimler.PutExtra("ad", FindViewById<EditText>(Resource.Id.editText1).Text);
                    hekimler.PutExtra("soyad", FindViewById<EditText>(Resource.Id.editText2).Text);
                    StartActivity(hekimler);
                }
                else

                {
                    if (!string.IsNullOrWhiteSpace(Intent.GetStringExtra("r_id")))
                    {


                        if (!string.IsNullOrWhiteSpace(Intent.GetStringExtra("m_id")))
                        {

                            Intent vezifeler = new Intent(this, typeof(vezifeler));
                            vezifeler.PutExtra("data", Intent.GetStringExtra("data"));
                     
                            vezifeler.PutExtra("r_id", Intent.GetStringExtra("r_id"));
                            vezifeler.PutExtra("m_id", Intent.GetStringExtra("m_id"));
                            StartActivity(vezifeler);
                        }
                        else
                        {
                            AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                            alertDialog.SetTitle("Bildiriş");
                            alertDialog.SetMessage("Axtarışa başlamaq üçün minimum 2 axtarış parametri seçin");
                            alertDialog.SetNeutralButton("Yaxşı", delegate
                            {

                                alertDialog.Dispose();
                            });
                            alertDialog.Show();
                        }
                    }
                    else
                    {
                        AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                        alertDialog.SetTitle("Bildiriş");
                        alertDialog.SetMessage("Axtarışa başlamaq üçün regionu seçin");
                        alertDialog.SetNeutralButton("Yaxşı", delegate
                        {

                            alertDialog.Dispose();
                        });
                        alertDialog.Show();
                    }


                }





            };
        }
    }
}
