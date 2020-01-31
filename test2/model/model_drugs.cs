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
   public class model_drugs
    {

        public string ID { get; set; }
        public string AD { get; set; }
        public string BPA_DOZA { get; set; }
        public string FORMA_TICARET { get; set; }
        public string FIRMA_OLKE { get; set; }
        public string QEYDIYYAT_NOMRE { get; set; }
        public string QEYDIYYAT_BITME_TARIXI { get; set; }
    }
}