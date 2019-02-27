using ESI.Classes;
using Newtonsoft.Json;

namespace ESI.Models
{
    /// <summary>
    /// Asteroid Belt class
    /// </summary>
    public class AsteroidBelt
    {
        /// <summary>
        /// Gets or sets the asteroid belt name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the stellar position of this asteroid belt
        /// </summary>
        [JsonProperty("position")]
        public StellarPosition Position { get; set; } = new StellarPosition();

        /// <summary>
        /// Gets or sets the ID of the solar system this asteroid belt is in
        /// </summary>
        [JsonProperty("system_id")]
        public int SystemID { get; set; }
    }
}
