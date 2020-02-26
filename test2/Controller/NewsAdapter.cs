using System;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Android.Content;
using Android.Views;
using Android.Widget;
using ESehiyye.model;
using static Android.Support.V7.Widget.RecyclerView;
namespace ESehiyye.Controller
{
    public class NewsAdapter : BaseAdapter<model.NewsStruct>
    {



            private ObservableCollection<model.NewsStruct> list;

            public NewsAdapter(ObservableCollection<model.NewsStruct> list)
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



            public override model.NewsStruct this[int position]
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


                    view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.news_item, parent, false);




                }
                
                view.FindViewById<TextView>(Resource.Id.newsTitle).Text = list[position].NAME;
            view.FindViewById<TextView>(Resource.Id.newsDescription).Text = list[position].TEXT;
            view.FindViewById<TextView>(Resource.Id.newsDate).Text = list[position].DT;

           


            return view;
            }

            public override long GetItemId(int position)
            {
                return position;
            }
        }
    }


