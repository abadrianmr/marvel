using Newtonsoft.Json;
using System.Collections.Generic;

namespace VisualApp.Models
{
    public class Appearance
    {
        public string Gender { get; set; }
        public string Race { get; set; }
        public List<string> Height { get; set; }
        public List<string> Weight { get; set; }

        [JsonProperty( "eye-color" )]
        public string Eyecolor { get; set; }

        [JsonProperty( "hair-color" )]
        public string Haircolor { get; set; }
    }
}
