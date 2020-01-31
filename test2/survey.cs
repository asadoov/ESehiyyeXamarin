using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace ESehiyye
{
    [Activity(Label = "survey")]
    public class survey : Activity
    {
        ListView listView1;
        ObservableCollection<model.surveys> list = new ObservableCollection<model.surveys>();
        ObservableCollection<model.surveys> filtred_list = new ObservableCollection<model.surveys>();
        List<model.users> user_data = new List<model.users>();
        surveys_adapter adapter;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.surveys);


            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Visible;

            user_data = JsonConvert.DeserializeObject<List<model.users>>(Preferences.Get("user_data", ""));
            model.db_select select = new model.db_select();

            list = await select.surveys(Preferences.Get("cypher1", "").ToString(), Preferences.Get("cypher2", "").ToString(), user_data[0].VESIQE_FIN, Intent.GetStringExtra("id"));
            //Toast.MakeText(ApplicationContext, list[0].DocAdSoyad, ToastLength.Long).Show();

            listView1 = FindViewById<ListView>(Resource.Id.listView1);
           
         
            if (list_filter(list,0).Count>0)
            {
                adapter = new surveys_adapter(list_filter(list, 0));
                listView1.Adapter = adapter;
            }
            else
            {
                AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                alertDialog.SetTitle("Bildiriş");
                alertDialog.SetMessage("Bu haqqda məlumat tapılmadı");
                alertDialog.SetNeutralButton("Tamam", delegate {
                    alertDialog.Dispose();

                });
                alertDialog.Show();
            }
           
            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Gone;
            var bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.menu);
           

            bottomNavigation.NavigationItemSelected += (s, e) =>
            {
                switch (e.Item.ItemId)
                {
                    case Resource.Id.surveys_by_doc:
                        if (list_filter(list, 0).Count() > 0)
                        {
                            adapter = new surveys_adapter(list_filter(list,0));
                            listView1.Adapter = adapter;
                        }
                        else
                        {
                            AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                            alertDialog.SetTitle("Bildiriş");
                            alertDialog.SetMessage("Bu haqqda məlumat tapılmadı");
                            alertDialog.SetNeutralButton("Tamam", delegate {
                                alertDialog.Dispose();

                            });
                            alertDialog.Show();
                        }
                        break;
                    case Resource.Id.helper_surveys:
                        if (list_filter(list, 1).Count() > 0)
                        {
                            adapter = new surveys_adapter(list_filter(list, 1));
                            listView1.Adapter = adapter;
                        }
                        else
                        {
                            AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                            alertDialog.SetTitle("Bildiriş");
                            alertDialog.SetMessage("Bu haqqda məlumat tapılmadı");
                            alertDialog.SetNeutralButton("Tamam", delegate {
                                alertDialog.Dispose();

                            });
                            alertDialog.Show();
                        }
                        break;
                    case Resource.Id.diagnosis:
                        
                        if (list_filter(list, 2).Count()>0)
                        {
                            adapter = new surveys_adapter(list_filter(list, 2));
                            listView1.Adapter = adapter;
                        }
                        else
                        {
                            AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                            alertDialog.SetTitle("Bildiriş");
                            alertDialog.SetMessage("Bu haqqda məlumat tapılmadı");
                            alertDialog.SetNeutralButton("Tamam", delegate {
                                alertDialog.Dispose();

                            });
                            alertDialog.Show();
                        }
                      
                        break;
                }
            };
        }
        ObservableCollection<model.surveys> list_filter (ObservableCollection<model.surveys> list, int type)
        {
            filtred_list.Clear();
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i].TYPE == type)
                {
                    filtred_list.Add(list[i]);
                }
            }
            return filtred_list;

        }
       
    }
}