using Android.App;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using AlertDialog = Android.App.AlertDialog;
using Xamarin.Essentials;
using ESehiyye.model;
using ESehiyye.Controller;


namespace ESehiyye
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppCompat.Light", MainLauncher = true)]
    public class MainActivity : Activity
    {

        EditText mail, pass;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            var current = Connectivity.NetworkAccess;
         
            base.OnCreate(savedInstanceState);

           
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.activity_main);

            if (current == NetworkAccess.Internet)
            {


                FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Gone;
                model.db_select select = new model.db_select();
                mail = FindViewById<EditText>(Resource.Id.mail);
                pass = FindViewById<EditText>(Resource.Id.pass);
                var savedChyper1 = Preferences.Get("cypher1", "");
                var savedCypher2 = Preferences.Get("cypher2", "");
                var savedUserData = Preferences.Get("user_data", "");
                if (savedChyper1 != "" && savedCypher2 != ""&&  savedUserData!= "")
                {
                    FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Visible;
                   
                    List<model.users> user_data = new List<model.users>();
                    user_data = JsonConvert.DeserializeObject<List<model.users>>(Preferences.Get("user_data", ""));
                   

                        Intent next = new Intent(this, typeof(ProfileActivity));

                        StartActivity(next);
                        FindViewById<Button>(Resource.Id.button1).Text = "Daxil ol";
                        FindViewById<Button>(Resource.Id.button1).Enabled = true;
                    FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Gone;

                }
                   
                
                FindViewById<Button>(Resource.Id.button1).Click += async delegate
                {
                    
                    string mailBox = FindViewById<EditText>(Resource.Id.mail).Text;
                    string passBox = FindViewById<EditText>(Resource.Id.pass).Text;

                    if (!string.IsNullOrEmpty(mailBox) && !string.IsNullOrEmpty(passBox))
                    {
                        if (IsValidEmail(mailBox))
                        {


                            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Visible;
                            FindViewById<Button>(Resource.Id.button1).Enabled = false;
                            FindViewById<Button>(Resource.Id.button1).Text = "Yüklənir...";

                            List<Cypher> cypher;

                            cypher = await select.SignIn(mail.Text, pass.Text);
                            if (!string.IsNullOrEmpty(cypher[0].cypher1) && !string.IsNullOrEmpty(cypher[0].cypher2))
                            {






                                List<model.users> user_data = new List<model.users>();
                                user_data = await select.UserAsync(cypher[0].cypher1, cypher[0].cypher2);
                                if (user_data.Count > 0)
                                {

                                    Intent next = new Intent(this, typeof(ProfileActivity));

                                    StartActivity(next);
                                    FindViewById<Button>(Resource.Id.button1).Text = "Daxil ol";
                                    FindViewById<Button>(Resource.Id.button1).Enabled = true;
                                   

                                    Preferences.Set("user_data", JsonConvert.SerializeObject(user_data));
                                    Preferences.Set("cypher1", cypher[0].cypher1);
                                    Preferences.Set("cypher2", cypher[0].cypher2);
                                }
                                else
                                {
                                   
                                    AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                                    alertDialog.SetTitle("Bildiriş");
                                    alertDialog.SetMessage("Email və ya şifrənin düzgünlüyünə diqqət edin");
                                    alertDialog.Show();
                                    // Toast.MakeText(ApplicationContext, "email ve ya shifre yalnishdir", ToastLength.Long).Show();
                                    FindViewById<Button>(Resource.Id.button1).Text = "Daxil ol";
                                    FindViewById<Button>(Resource.Id.button1).Enabled = true;
                                }
                               

                            }
                            else
                            {
                                AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                                alertDialog.SetTitle("Bildiriş");
                                alertDialog.SetMessage("Email və ya şifrənin düzgünlüyünə diqqət edin");
                                alertDialog.Show();
                                // Toast.MakeText(ApplicationContext, "email ve ya shifre yalnishdir", ToastLength.Long).Show();
                                FindViewById<Button>(Resource.Id.button1).Text = "Daxil ol";
                                FindViewById<Button>(Resource.Id.button1).Enabled = true;
                            }
                            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Gone;
                        }

                        else
                        {
                            FindViewById<EditText>(Resource.Id.mail).Error = "Zəhmət olmasa Email-nızın doğruluğuna diqqət edin";
                        }

                    }
                    else
                    {
                        if (string.IsNullOrEmpty(mailBox))
                        {
                            FindViewById<EditText>(Resource.Id.mail).Error = "Zəhmət olmasa Email-nızı doldurum";
                        }
                        if (string.IsNullOrEmpty(passBox)) {
                            FindViewById<EditText>(Resource.Id.pass).Error = "Zəhmət olmasa şifrənizi doldurum"; }
                       
                    }

                };
            }
            else
            {
                AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                alertDialog.SetTitle("Bildiriş");
                alertDialog.SetMessage("Lütfən şəbəkə bağlantınızı yoxlayın");
                alertDialog.Show();
            }
        }
       
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        [Java.Interop.Export("passwordRecovery")]
        public void passwordRecovery(View v)
        {


            Intent passRecovery = new Intent(this, typeof(PasswordRecoveryActivity));

            StartActivity(passRecovery);
            //Toast.MakeText(ApplicationContext, "esdasad", ToastLength.Long).Show();

        }
        [Java.Interop.Export("signUpClick")]
        public void signUpClick(View v)
        {


            Intent signUp = new Intent(this, typeof(SignUpActivity));

            StartActivity(signUp);
            //Toast.MakeText(ApplicationContext, "esdasad", ToastLength.Long).Show();

        }
      

    }
}