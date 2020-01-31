using System;
using Newtonsoft.Json;

namespace ESehiyye.model
{
    public class vezifeler
    {
        [JsonProperty(PropertyName = "ID")]

        public int ID { get; set; }

        [JsonProperty(PropertyName = "AD")]
        public string AD { get; set; }
    }
}
