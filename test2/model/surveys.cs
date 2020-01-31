using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ESehiyye.model
{
  public  class surveys
    {
        public string ID { get; set; }
        public string MUAYINE_AD { get; set; }
        public string MUAYINE_TARIX { get; set; }
        public int TYPE { get; set; }
        public string HEKIM_REY { get; set; }
        public string XBT { get; set; }
    }
}