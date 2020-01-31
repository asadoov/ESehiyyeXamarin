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
    public class elektron_xidmetler_adapter : BaseAdapter<string>
    {
        private List<string> info;

       
        public elektron_xidmetler_adapter (List<string> info)
        {
            this.info = info;
            
           

        }
        public override int Count
        {
            get
            {
                return info.Count;
            }
        }



        public override string this[int position]
        {
            get
            {
                return info[position];

            }
           
        }

        

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if (view == null)
            {


                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.elektron_xidmetler_item, parent, false);




            }
            TextView textView1 = view.FindViewById<TextView>(Resource.Id.info);
            textView1.Text = info[position];
            view.FindViewById<TextView>(Resource.Id.reg_info).Text = "";
          


            return view;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
    }
}
