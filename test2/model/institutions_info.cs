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
    public class institutions_info:institutions
    {
        public string AD { get; set; }
        public string UNVAN { get; set; }
        public string TEL { get; set; }
        public string EMAIL { get; set; }
        public string FAX { get; set; }
    }
}