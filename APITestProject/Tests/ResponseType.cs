using Newtonsoft.Json;
using System.Collections.Generic;

namespace APITestProject
{
    public class ResponseType
    {
        [JsonProperty("Name")]
        public string? Name { get; set; }

        [JsonProperty("CanRelist")]
        public bool CanRelist { get; set; }

        [JsonProperty("Promotions")]
        public List<Promotion>? Promotions { get; set; }
    }

    public class Promotion
    {
        [JsonProperty("Name")]
        public string? Name { get; set; }

        [JsonProperty("Description")]
        public string? Description { get; set; }
    }
}
