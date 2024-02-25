using Newtonsoft.Json;
using System.Collections.Generic;

namespace VisualApp.Models
{
    public class Biography
    {
        [JsonProperty( "full-name" )]
        public string Fullname { get; set; }

        [JsonProperty( "alter-egos" )]
        public string Alteregos { get; set; }
        public List<string> Aliases { get; set; }

        [JsonProperty( "place-of-birth" )]
        public string Placeofbirth { get; set; }

        [JsonProperty( "first-appearance" )]
        public string Firstappearance { get; set; }
        public string Publisher { get; set; }
        public string Alignment { get; set; }
    }
}
