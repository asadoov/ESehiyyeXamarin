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
    public class randevu_patients_adapter : BaseAdapter<reservations_doctor>
    {
        private ObservableCollection<reservations_doctor> list;
  
        public randevu_patients_adapter(ObservableCollection<model.reservations_doctor> list)
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



        public override reservations_doctor this[int position]
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

               
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.randevu_patient_item, parent, false);
               
                
       

            }
            TextView textView1 = view.FindViewById<TextView>(Resource.Id.patient_name);
            textView1.Text = list[position].AdSoyad;
            view.FindViewById<TextView>(Resource.Id.patient_randevu_date).Text = list[position].RandevuDate + " saat: " + list[position].RandevuTime;
            switch (list[position].RandevuStatus)
            {
                case 0:
                    view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(Resource.Drawable.@unchecked);
                    break;
                case 1:
                    break;
                case 2:
                    view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(Resource.Drawable.@checked);

                    //view.FindViewById<TextView>(Resource.Id.patient_status).Text = "✔️";
                    break;
                case 3:
                    view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(Resource.Drawable.warning);
                    view.FindViewById<TextView>(Resource.Id.patient_randevu_date).Text += " (imtina edilib)";
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
