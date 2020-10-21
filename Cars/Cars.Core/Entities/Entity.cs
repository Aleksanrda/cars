using Newtonsoft.Json;

namespace Cars.Core.Entities
{
    public abstract class Entity
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}
