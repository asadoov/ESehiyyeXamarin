using System;
using Newtonsoft.Json;

namespace ESehiyye.model
{
    public class doctors
    {
        [JsonProperty(PropertyName = "KADR_ID")]

        public int KADR_ID { get; set; }

        [JsonProperty(PropertyName = "VEZIFE_ID")]
        public int VEZIFE_ID { get; set; }

        [JsonProperty(PropertyName = "MUES_ID")]
        public int MUES_ID { get; set; }

        [JsonProperty(PropertyName = "AD_SOYAD")]
        public string AD_SOYAD { get; set; }

        [JsonProperty(PropertyName = "VEZIFE")]
        public string VEZIFE { get; set; }

        [JsonProperty(PropertyName = "MUES")]
        public string MUES { get; set; }

        [JsonProperty(PropertyName = "USERID")]

        public int USERID { get; set; }

       
    }
}
