using System;
using Newtonsoft.Json;
namespace ESehiyye.model
{
    public class Cypher
    {
        [JsonProperty(PropertyName = "cypher1")]
        public string cypher1 { get; set; }
        [JsonProperty(PropertyName = "cypher2")]
        public string cypher2 { get; set; }


    }
}
