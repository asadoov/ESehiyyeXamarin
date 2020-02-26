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
    [Activity(Label = "immunity")]
    public class immunity : Activity
    {
        List<string> immunity_list;
        ArrayAdapter<string> mAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.immunity);

            FindViewById<TextView>(Resource.Id.toolbarTitle).Text = "İmmunoprofilaktika";
            FindViewById<ImageButton>(Resource.Id.backBtn).Visibility = ViewStates.Visible;

            immunity_list = new List<string>();
            immunity_list.AddRange(new string[] {"Doğumdan sonra 12 saat ərzində",
           "4-7-ci gün",
                "2 aylıqda",
                "3 aylıqda",
                "6 aylıqda",
                "12 aylıqda",
                "18 aylıqda",
                "6 yaşında"});
            mAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, immunity_list);

            FindViewById<ListView>(Resource.Id.listView1).Adapter = mAdapter;
            FindViewById<ListView>(Resource.Id.listView1).ItemClick += instClick;
        }
        private void instClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Visible;
            AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
            switch (e.Position)
            {
                case 0:
                    alertDialog.SetTitle("Doğumdan sonra 12 saat ərzində");
                    alertDialog.SetMessage("Hepatit B xəstəliyinə qarşı peyvənd");
                    alertDialog.SetNeutralButton("Tamam", delegate {
                        alertDialog.Dispose();

                    });
                    break;
                case 1:
                    alertDialog.SetTitle("4-7-ci gün");
                    alertDialog.SetMessage("Vərəm əleyhinə peyvənd\nPoliomielitə qarşı peyvənd");
                    alertDialog.SetNeutralButton("Tamam", delegate {
                        alertDialog.Dispose();

                    });
                    break;
                case 2:
                    alertDialog.SetTitle("2 aylıqda");
                    alertDialog.SetMessage("Difteriya, göyöskürək, tetanus, hepatit B və B tipli hemofil infeksiyaya qarşı peyvənd\n\nPoliomielitə qarşı peyvənd\n\nPnevmokok infeksiyalarına qarşı peyvənd");
                    alertDialog.SetNeutralButton("Tamam", delegate {
                        alertDialog.Dispose();

                    });
                    break;
                case 3:
                    alertDialog.SetTitle("3 aylıqda");
                    alertDialog.SetMessage("Difteriya, göyöskürək, tetanus, hepatit B və B tipli hemofil infeksiyaya qarşı peyvənd\n\nPoliomielitə qarşı peyvənd");
                    alertDialog.SetNeutralButton("Tamam", delegate {
                        alertDialog.Dispose();

                    });
                    break;
                case 4:
                    alertDialog.SetTitle("6 aylıqda");
                    alertDialog.SetMessage("Pnevmokok infeksiyalarına qarşı peyvənd");
                    alertDialog.SetNeutralButton("Tamam", delegate {
                        alertDialog.Dispose();

                    });
                    break;
                case 5:
                    alertDialog.SetTitle("12 aylıqda");
                    alertDialog.SetMessage("Qızılca, parotit və məxmərəyə qarşı peyvənd\n\nVitamin A");
                    alertDialog.SetNeutralButton("Tamam", delegate {
                        alertDialog.Dispose();

                    });
                    break;
                case 6:
                    alertDialog.SetTitle("18 aylıqda");
                    alertDialog.SetMessage("Difteriya, göyöskürək, tetanus qarşı peyvənd\n\nPoliomelitə qarşı peyvənd\n\nVitamin A");
                    alertDialog.SetNeutralButton("Tamam", delegate {
                        alertDialog.Dispose();

                    });
                    break;
                case 7:
                    alertDialog.SetTitle("6 yaşında");
                    alertDialog.SetMessage("Qızılca, parotit və məxmərəyə qarşı peyvənd\n\nDifteriya və tetanus-a qarşı peyvənd \n\nVitamin A");
                    alertDialog.SetNeutralButton("Tamam", delegate {
                        alertDialog.Dispose();

                    });
                    break;
            }
           
            alertDialog.Show();

            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Gone;
        }
        [Java.Interop.Export("backClicked")]
        public void backClicked(View v)
        {


            OnBackPressed();
            //Toast.MakeText(ApplicationContext, "esdasad", ToastLength.Long).Show();

        }
    }
}