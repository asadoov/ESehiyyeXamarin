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
    public class drugs_adapter : BaseAdapter<model.model_drugs>
    {
        private ObservableCollection<model.model_drugs> list;

        public drugs_adapter(ObservableCollection<model.model_drugs> list)
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



        public override model_drugs this[int position]
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


                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.drugs_item, parent, false);




            }
            TextView textView1 = view.FindViewById<TextView>(Resource.Id.first_ln);
            textView1.Text = list[position].AD;

            switch (list[position].QEYDIYYAT_NOMRE)
            {

                case "Yenidən qeydiyyat prosedurundadır":
                    view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(Resource.Drawable.warning);

                    break;
                default:
                    view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(Resource.Drawable.@checked);

                    break;
            }


            return view;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
    }
}
