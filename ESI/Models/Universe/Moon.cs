using ESI.Classes;
using Newtonsoft.Json;

namespace ESI.Models
{
    /// <summary>
    /// Moon class
    /// </summary>
    public class Moon
    {
        /// <summary>
        /// Gets or sets the moon ID
        /// </summary>
        [JsonProperty("moon_id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the moon name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the stellar position of the moon
        /// </summary>
        [JsonProperty("position")]
        public StellarPosition Position { get; set; } = new StellarPosition();

        /// <summary>
        /// Gets or sets the ID of the solar system this moon is in
        /// </summary>
        [JsonProperty("system_id")]
        public int SystemID { get; set; }
    }
}
