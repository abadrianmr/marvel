using Newtonsoft.Json;

namespace VisualApp.Models
{
    public class Connections
    {
        [JsonProperty( "group-affiliation" )]
        public string Groupaffiliation { get; set; }
        public string Relatives { get; set; }
    }
}
