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
    public class patient_hospital_requests_adapter : BaseAdapter<model.institutions>
    {
        private ObservableCollection<model.institutions> list;

        public patient_hospital_requests_adapter(ObservableCollection<model.institutions> list)
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



        public override model.institutions this[int position]
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
            textView1.Text = list[position].MUES_AD;
            view.FindViewById<TextView>(Resource.Id.unique_id).Text = "Müraciət tarixi: " + list[position].BASHLAMA_TARIXI;
            view.FindViewById<TextView>(Resource.Id.aaa).Text = list[position].MUES_AD[0].ToString();




            return view;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
    }
}
