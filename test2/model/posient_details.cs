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
using Newtonsoft.Json;

namespace ESehiyye.model
{
  public class posient_details
    {

        [JsonProperty("FIN")]
        public string Fin { get; set; }

        [JsonProperty("AD_SOYAD")]
        public string AdSoyad { get; set; }

        [JsonProperty("MOBILE_NUMBER")]
        public string MobNumber { get; set; }

        [JsonProperty("UNIKALKOD")]
        public string Unikalkod { get; set; }


    }
}