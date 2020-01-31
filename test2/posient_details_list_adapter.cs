using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Android.Content;
using Android.Views;
using Android.Widget;
using ESehiyye.model;
using static Android.Support.V7.Widget.RecyclerView;

namespace ESehiyye
{
    public class patients_detail_adapter : BaseAdapter<model.posient_details>
    {
        private ObservableCollection<model.posient_details> list;

        public patients_detail_adapter(ObservableCollection<model.posient_details> list)
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

      

        public override model.posient_details this[int position]
        {
            get
            {
                return list[position];
            }
        }



        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if (view == null)
            {


                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.details_item, parent, false);




            }
            TextView textView1 = view.FindViewById<TextView>(Resource.Id.posient_name);
            textView1.Text = list[position].AdSoyad;
            view.FindViewById<TextView>(Resource.Id.unique_id).Text = "Unikal kod: "+list[position].Unikalkod;
            view.FindViewById<TextView>(Resource.Id.aaa).Text = list[position].AdSoyad[0].ToString(); 




            return view;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
    }
}
