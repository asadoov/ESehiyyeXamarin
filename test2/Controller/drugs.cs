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
using Xamarin.Essentials;

namespace ESehiyye
{
    [Activity(Label = "drugs")]
    public class drugs : Activity
    {
        Android.App.AlertDialog.Builder alertDialog;
        ListView listView1;
        ObservableCollection<model.model_drugs> list = new ObservableCollection<model.model_drugs>();
        ObservableCollection<model.model_drugs> filtered_list = new ObservableCollection<model.model_drugs>();
        drugs_adapter adapter;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.drugs);
            // Create your application here


            FindViewById<TextView>(Resource.Id.toolbarTitle).Text = "Dərman vasitələri";
            FindViewById<ImageButton>(Resource.Id.backBtn).Visibility = ViewStates.Visible;
            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Visible;

            
            model.db_select select = new model.db_select();

            list = await select.get_drugs(Preferences.Get("cypher1", "").ToString(), Preferences.Get("cypher2", "").ToString());
            // Toast.MakeText(ApplicationContext, list[0].ToString(), ToastLength.Long).Show();
            listView1 = FindViewById<ListView>(Resource.Id.listView1);
            if (list.Count > 0)
            {


                adapter = new drugs_adapter(list);
                listView1.Adapter = adapter;
            }
            else
            {
                alertDialog = new Android.App.AlertDialog.Builder(this);
                alertDialog.SetTitle("Bildiriş");
                alertDialog.SetMessage("Dərman vasitələrini yükləmək mümkün olmadı");
                //alertDialog.SetPositiveButton("Tamam", delegate
                //{
                //    alertDialog.Dispose();
                //});
                alertDialog.Show();
            }
           

         
            FindViewById<FrameLayout>(Resource.Id.progressBarHolder).Visibility = ViewStates.Gone;
            FindViewById<SearchView>(Resource.Id.searchView1).QueryTextChange += search;
        }
        [Java.Interop.Export("backClicked")]
        public void backClicked(View v)
        {


            OnBackPressed();
            //Toast.MakeText(ApplicationContext, "esdasad", ToastLength.Long).Show();

        }
        private void search(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            var searchText = e.NewText;
            switch (searchText)
            {
                case "":
                    adapter = new drugs_adapter(list);
                    break;
                default:
                    filtered_list.Clear();
                    foreach (model.model_drugs item in list)
                    {
                        if (item.AD.ToLower().Contains(searchText.ToLower()))
                        {
                            filtered_list.Add(item);
                        }
                    }
                   
                    adapter = new drugs_adapter(filtered_list);
                  
                    break;
            }
            listView1.Adapter = adapter;
            

        }
    }
}