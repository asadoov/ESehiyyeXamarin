using System;
using Newtonsoft.Json;

namespace ESehiyye.model
{
    public class regions_and_inst
    {
        [JsonProperty(PropertyName = "ID")]

        public int ID { get; set; }

        [JsonProperty(PropertyName = "AD")]
        public string AD { get; set; }

        
    }
}
