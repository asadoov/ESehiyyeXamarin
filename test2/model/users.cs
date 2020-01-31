using System;
using Newtonsoft.Json;

namespace ESehiyye.model
{
    public class users
    {
        [JsonProperty(PropertyName = "ID")]

        public int ID { get; set; }

        [JsonProperty(PropertyName="NAME")]
        public string NAME { get; set; }

        [JsonProperty(PropertyName = "EMAIL")]
        public string EMAIL { get; set; }

        [JsonProperty(PropertyName = "STATUS")]
        public string STATUS { get; set; }

        [JsonProperty(PropertyName = "VESIQE_FIN")]
        public string VESIQE_FIN { get; set; }

        [JsonProperty(PropertyName = "MOBILE")]
        public string MOBILE { get; set; }

        [JsonProperty(PropertyName = "BOY")]
        
        public int BOY { get; set; }

        [JsonProperty(PropertyName = "YASH")]
       
        public int YASH { get; set; }

        [JsonProperty(PropertyName = "QAN")]
        public string QAN { get; set; }

        [JsonProperty(PropertyName = "PHOTO_BASE64")]
        public string PHOTO_BASE64 { get; set; }



    }
}
