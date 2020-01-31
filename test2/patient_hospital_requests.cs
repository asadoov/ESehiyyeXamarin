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
    [Activity(Label = "patient_hospital_requests")]
    public class patient_hospital_requests : Activity
    {
        ListView ambulator_list,stationar_list;
        ObservableCollection<model.institutions> list = new ObservableCollection<model.institutions>();
        ObservableCollection<model.institutions> ambulator = new ObservableCollection<model.institutions>();
        ObservableCollection<model.institutions> stationar = new ObservableCollection<model.institutions>();
        AlertDialog.Builder alertDialog;

        List<model.users> user_data = new List<model.users>();
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.patient_hospital_requests);
            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Visible;

            user_data = JsonConvert.DeserializeObject<List<model.users>>(Preferences.Get("user_data", ""));
            model.db_select select = new model.db_select();

            list = await select.get_info(Preferences.Get("cypher1", "").ToString(), Preferences.Get("cypher2", "").ToString(), user_data[0].VESIQE_FIN, Intent.GetStringExtra("patient_id"));
            // Toast.MakeText(ApplicationContext, list[0].ToString(), ToastLength.Long).Show();

            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i].TYPE=="1")
                {
                    stationar.Add(list[i]);
                }
                if (list[i].TYPE=="0")
                {

                    ambulator.Add(list[i]);
                }
                
            }
            patient_hospital_requests_adapter stationar_adapter = new patient_hospital_requests_adapter(stationar);
            patient_hospital_requests_adapter ambulator_adapter = new patient_hospital_requests_adapter(ambulator);

            ambulator_list = FindViewById<ListView>(Resource.Id.ambulatory);
            stationar_list = FindViewById<ListView>(Resource.Id.stationary);

            ambulator_list.Adapter = ambulator_adapter;
           stationar_list.Adapter = stationar_adapter;
            ambulator_list.ItemClick += ambulator_click;
            stationar_list.ItemClick += stationar_click;
            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Gone;
            // Create your application here
        }

        private void ambulator_click(object sender, AdapterView.ItemClickEventArgs e)
        {

            Intent survey = new Intent(this, typeof(survey));
            survey.PutExtra("id", ambulator[e.Position].ID);
            StartActivity(survey);

        }
        private void stationar_click(object sender, AdapterView.ItemClickEventArgs e)
        {

            Intent survey = new Intent(this, typeof(survey));
            survey.PutExtra("id", stationar[e.Position].ID);
            StartActivity(survey);

        }
    }
}