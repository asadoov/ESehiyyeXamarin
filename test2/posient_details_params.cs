
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

namespace ESehiyye
{
    [Activity(Label = "posient_details_params")]
    public class posient_details_params : Activity
    {
        AlertDialog.Builder alertDialog;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.posient_details_params);
            FindViewById<Button>(Resource.Id.button3).Click += delegate
            {
                //Кнопка поиска
                if (
                    FindViewById<EditText>(Resource.Id.editText1).Text != ""
                    ||
                    FindViewById<EditText>(Resource.Id.editText2).Text != ""
                    ||
                    FindViewById<EditText>(Resource.Id.editText3).Text != ""
                    ||
                    FindViewById<EditText>(Resource.Id.editText4).Text != ""
                    ||
                     FindViewById<EditText>(Resource.Id.editText5).Text != ""
                   )
                {



                    if ((
                       FindViewById<EditText>(Resource.Id.editText1).Text == ""
                       &&
                       FindViewById<EditText>(Resource.Id.editText2).Text == ""
                       &&
                       FindViewById<EditText>(Resource.Id.editText3).Text != "") || (
                       FindViewById<EditText>(Resource.Id.editText1).Text != ""
                       &&
                       FindViewById<EditText>(Resource.Id.editText2).Text == ""
                       &&
                       FindViewById<EditText>(Resource.Id.editText3).Text == "") ||
                       (
                       FindViewById<EditText>(Resource.Id.editText1).Text == ""
                       &&
                       FindViewById<EditText>(Resource.Id.editText2).Text != ""
                       &&
                       FindViewById<EditText>(Resource.Id.editText3).Text == ""))


                    {
                        if (FindViewById<EditText>(Resource.Id.editText4).Text != "" || FindViewById<EditText>(Resource.Id.editText5).Text != "")
                        {

                            Intent patient_details = new Intent(this, typeof(posient_details));
                            patient_details.PutExtra("name", FindViewById<EditText>(Resource.Id.editText1).Text);
                            patient_details.PutExtra("surname", FindViewById<EditText>(Resource.Id.editText2).Text);
                            patient_details.PutExtra("dad_name", FindViewById<EditText>(Resource.Id.editText3).Text);
                            patient_details.PutExtra("unique_id", FindViewById<EditText>(Resource.Id.editText4).Text);
                            patient_details.PutExtra("patient_fin", FindViewById<EditText>(Resource.Id.editText5).Text);
                            StartActivity(patient_details);
                        }
                        else
                        {
                            alertDialog = new AlertDialog.Builder(this);

                            alertDialog.SetMessage("Ad və Soyad, Ad və Ata adı, Soyad və Ata adı bir parametr kimi birlikdə qeyd edilir");

                            alertDialog.Show();
                        }
                       

                    }
                   
                    else
                    {
                        Intent patient_details = new Intent(this, typeof(posient_details));
                        patient_details.PutExtra("name", FindViewById<EditText>(Resource.Id.editText1).Text);
                        patient_details.PutExtra("surname", FindViewById<EditText>(Resource.Id.editText2).Text);
                        patient_details.PutExtra("dad_name", FindViewById<EditText>(Resource.Id.editText3).Text);
                        patient_details.PutExtra("unique_id", FindViewById<EditText>(Resource.Id.editText4).Text);
                        patient_details.PutExtra("patient_fin", FindViewById<EditText>(Resource.Id.editText5).Text);
                        StartActivity(patient_details);
                    }
                }
                else
                {

                    alertDialog = new AlertDialog.Builder(this);

                    alertDialog.SetMessage("Axtarışa başlamaq üçün minimum 1 parametr daxil edilməlidi. Ad və Soyad bir parametr kimi qeyd edilir");

                    alertDialog.Show();
                }

            };
        }
    }
}
