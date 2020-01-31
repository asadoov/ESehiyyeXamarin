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

namespace ESehiyye
{
    class surveys_adapter : BaseAdapter<model.surveys>
    {
        private ObservableCollection<model.surveys> list;


        public surveys_adapter(ObservableCollection<model.surveys> list)
        {
            this.list = list;
        }

        public override int Count
        {
            get
            {
                return list.Count;
            }
        }
        public override model.surveys this[int position]
        {
            get
            {
                return list[position];
            }
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if (view == null)
            {


                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.surveys_item, parent, false);




            }
           


            switch (list[position].TYPE)
            {
               case 0:
                    view.FindViewById<TextView>(Resource.Id.first_ln).Text = list[position].MUAYINE_AD;
                    view.FindViewById<TextView>(Resource.Id.second_ln).Text = "Həkimin rəyi: " + list[position].HEKIM_REY;
                    view.FindViewById<TextView>(Resource.Id.third_ln).Text = "XBT: " + list[position].XBT;

                    break;
                case 1:
                    view.FindViewById<TextView>(Resource.Id.first_ln).Text = list[position].MUAYINE_AD;
                    view.FindViewById<TextView>(Resource.Id.second_ln).Text = "Nəticə: " + list[position].HEKIM_REY;
                    view.FindViewById<TextView>(Resource.Id.third_ln).Text = "";

                    break;
                case 2:
                    view.FindViewById<TextView>(Resource.Id.first_ln).Text = list[position].MUAYINE_AD;
                   view.FindViewById<TextView>(Resource.Id.second_ln).Text = "Həkimin rəyi: " + list[position].HEKIM_REY;
                    view.FindViewById<TextView>(Resource.Id.third_ln).Text = "XBT: " + list[position].XBT;
                    break;

            }


            return view;


        }


    }
}