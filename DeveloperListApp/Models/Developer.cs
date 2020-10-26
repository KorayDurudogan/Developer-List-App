using Newtonsoft.Json;

namespace DeveloperListApp.Models
{
    public class Developer
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }
    }
}
