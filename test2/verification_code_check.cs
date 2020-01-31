using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text.Method;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace ESehiyye
{
    [Activity(Label = "verification_code_check")]
    public class verification_code_check : Activity
    {
        List<model.users> user_data = new List<model.users>();
        AlertDialog.Builder alertDialog;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            EditText txt1, txt2, txt3, txt4;
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.verification_code_check);
            user_data = JsonConvert.DeserializeObject<List<model.users>>(Preferences.Get("user_data", ""));
            model.db_insert insert = new model.db_insert();
            txt1 = FindViewById<EditText>(Resource.Id.editText1);
            txt2 = FindViewById<EditText>(Resource.Id.editText2);
            txt3 = FindViewById<EditText>(Resource.Id.editText3);
            txt4 = FindViewById<EditText>(Resource.Id.editText4);


            txt1.TextChanged += delegate
            {
                if (txt1.Text.Length > 1)
                {
           
                    txt2.Text = txt1.Text[1].ToString();
                    txt1.Text = txt1.Text[0].ToString();
                    txt2.Enabled = true;
                   // txt1.Enabled = false;
                    txt2.SetSelection(txt2.Text.Length);
                    txt2.RequestFocusFromTouch();
                }
 
            };
            txt2.TextChanged += delegate
            {
                if (txt2.Text.Length > 1)
                {

                    txt3.Text = txt2.Text[1].ToString();
                    txt2.Text = txt2.Text[0].ToString();
                    txt3.Enabled = true;
                 //   txt2.Enabled = false;
                    txt3.SetSelection(txt3.Text.Length);
                    txt3.RequestFocus();
                }
                if (txt2.Text.Length < 1)
                {

                    txt1.Enabled = true;
                  //  txt2.Enabled = false;
                    txt1.SetSelection(txt1.Text.Length);
                    txt1.RequestFocus();
                }
              
            };

            txt3.TextChanged += delegate
            {
                if (txt3.Text.Length > 1)
                {

                    txt4.Text = txt3.Text[1].ToString();
                    txt3.Text = txt3.Text[0].ToString();
                    txt4.Enabled = true;
                    //txt3.Enabled = false;
                   
                    txt4.SetSelection(txt4.Text.Length);
                    txt4.RequestFocus();
                }
                if (txt3.Text.Length < 1)
                {

                    txt2.Enabled = true;
                    //txt3.Enabled = false;
                    txt2.SetSelection(txt2.Text.Length);
                    txt2.RequestFocus();
                }
                
            };

            txt4.TextChanged += async delegate
            {
                txt1.Enabled = false;
                txt2.Enabled = false;
                txt3.Enabled = false;
                txt4.Enabled = false;
                if (txt1.Text!=""&&txt2.Text!=""&&txt3.Text!=""&&txt4.Text!="")
                {
                    FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Visible;
                    string status = await insert.verificationpincode(Preferences.Get("cypher1", "").ToString(), Preferences.Get("cypher2", "").ToString(), user_data[0].VESIQE_FIN, txt1.Text[0].ToString() + txt2.Text[0].ToString() + txt3.Text[0].ToString() + txt4.Text[0].ToString());

                    dynamic d = JsonConvert.DeserializeObject(status);
                    if (Convert.ToInt32(d[0]["VERIFICATION_PIN_CODE"]) == 0)
                    {
                        Intent get_info = new Intent(this, typeof(patient_hospital_requests));
                        get_info.PutExtra("patient_id", Intent.GetStringExtra("patient_id"));
                        StartActivity(get_info);
                    }
                    else
                    {
                        alertDialog = new AlertDialog.Builder(this);
                        alertDialog = new AlertDialog.Builder(this);
                        alertDialog.SetTitle("Bildiriş");
                        alertDialog.SetMessage("Şifrə yalnışdır!");



                    }
                     FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Visible;
                    // Toast.MakeText(ApplicationContext, txt1.Text[0].ToString() + txt2.Text[0].ToString() + txt3.Text[0].ToString() + txt4.Text[0].ToString(), ToastLength.Long).Show();
                }

            };










        }


    }
}