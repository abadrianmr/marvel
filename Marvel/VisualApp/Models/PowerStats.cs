using Newtonsoft.Json;
using VisualApp.Helpers;

namespace VisualApp.Models
{
    public class PowerStats
    {
        [JsonConverter( typeof( StringToIntConverter ) )]
        public int? Intelligence { get; set; }
        [JsonConverter( typeof( StringToIntConverter ) )]
        public int? Strength { get; set; }
        [JsonConverter( typeof( StringToIntConverter ) )]
        public int? Speed { get; set; }
        [JsonConverter( typeof( StringToIntConverter ) )]
        public int? Durability { get; set; }
        [JsonConverter( typeof( StringToIntConverter ) )]
        public int? Power { get; set; }
        [JsonConverter( typeof( StringToIntConverter ) )]
        public int? Combat { get; set; }
    }
}
