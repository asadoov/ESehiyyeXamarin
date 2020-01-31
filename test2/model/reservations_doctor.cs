

using Newtonsoft.Json;

namespace ESehiyye.model
{
    public class reservations_doctor
    {

        [JsonProperty("RANDEVU_ID")]

        public int RandevuId { get; set; }

        [JsonProperty("AD_SOYAD")]
        public string AdSoyad { get; set; }

        [JsonProperty("MOB_NUMBER")]
        public string MobNumber { get; set; }

        [JsonProperty("RANDEVU_DATE")]
        public string RandevuDate { get; set; }

        [JsonProperty("RANDEVU_TIME")]
        public string RandevuTime { get; set; }

        [JsonProperty("RANDEVU_STATUS")]
        public long RandevuStatus { get; set; }

        [JsonProperty("CURRENT_DT")]
        public string CurrentDt { get; set; }

        [JsonProperty("UNIKALKOD")]
        public string Unikalkod { get; set; }

        [JsonProperty("OPEN")]
        public int Open { get; set; }
    }
}
