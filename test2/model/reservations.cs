using System;
using Newtonsoft.Json;

namespace ESehiyye.model
{
    public class reservations
    {

        [JsonProperty("ID")]
        
        public int Id { get; set; }

        [JsonProperty("AD_SOYAD")]
        public string AdSoyad { get; set; }

        [JsonProperty("DOC_AD_SOYAD")]
        public string DocAdSoyad { get; set; }

        [JsonProperty("VEFIZE")]
        public string Vefize { get; set; }

        [JsonProperty("TARIX")]
        public string Tarix { get; set; }

        [JsonProperty("SAAT")]
        public string Saat { get; set; }

        [JsonProperty("HEKIM_USERID")]
       
        public int HekimUserid { get; set; }

        [JsonProperty("POSIENT_USERID")]
        
        public int PosientUserid { get; set; }

        [JsonProperty("DOC_PHOTO")]
        public string DocPhoto { get; set; }

        [JsonProperty("MUES_AD")]
        public string MuesAd { get; set; }

        [JsonProperty("MUES_UNVAN")]
        public string MuesUnvan { get; set; }

        [JsonProperty("MUES_TEL")]
        public string MuesTel { get; set; }
    }
}
