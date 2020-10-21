using Newtonsoft.Json;

namespace Cars.Core.Entities
{
    public class Car : Entity
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "volume")]
        public double Volume { get; set; }

        [JsonProperty(PropertyName = "consumption")]
        public double Consumption { get; set; }

        [JsonProperty(PropertyName = "capacity")]
        public int Capacity { get; set; }

        [JsonProperty(PropertyName = "price")]
        public int Price { get; set; }
    }
}
