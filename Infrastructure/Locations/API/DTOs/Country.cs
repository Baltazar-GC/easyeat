using Newtonsoft.Json;

namespace easyeat.Infrastructure.Locations.API.DTOs
{
    public class Country
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
