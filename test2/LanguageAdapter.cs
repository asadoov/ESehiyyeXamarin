using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using ESehiyye.model;

namespace ESehiyye
{
    public class LanguageAdapter:BaseAdapter<model.reservations>
    {
        private List<model.reservations> list;
        private Context context;
        public LanguageAdapter(Context context,List<model.reservations> list)
        {
            this.list = list;
            this.context = context;
        }
        public override int Count
        {
            get
            {
                return list.Count;
            }
        }

       

        public override reservations this[int position]
        {
            get
            {
                return list[position];
            }
        }

       

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view==null)
            {
                
              
                view = LayoutInflater.From(context).Inflate(Resource.Layout.randevu_item, null, false);
               
            }
            DateTime oDate = DateTime.ParseExact(list[position].Tarix, "dd.MM.yyyy", null);
            TextView textView1 = view.FindViewById<TextView>(Resource.Id.textView1);
            textView1.Text = oDate.ToString("dd \n MMMM", new System.Globalization.CultureInfo("az-Latn-AZ")) + "\n" + list[position].Saat;
            view.FindViewById<TextView>(Resource.Id.textView2).Text = list[position].Vefize + "\n" + list[position].DocAdSoyad;

            return view;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
    }
}
