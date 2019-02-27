using ESI.Classes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ESI.Models
{
    /// <summary>
    /// System Class
    /// </summary>
    public class SolarSystem
    {
        /// <summary>
        /// Gets or sets the system id
        /// </summary>
        [JsonProperty("system_id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the constellation id
        /// </summary>
        [JsonProperty("constellation_id")]
        public int ConstellationID { get; set; }

        /// <summary>
        /// Gets or sets the system name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the planets within the system
        /// </summary>
        [JsonProperty("planets")]
        public List<Planet> Planets { get; set; } = new List<Planet>();

        /// <summary>
        /// Gets or sets the stellar position of the system
        /// </summary>
        [JsonProperty("position")]
        public StellarPosition Position { get; set; } = new StellarPosition();

        /// <summary>
        /// Gets or sets the system security class
        /// </summary>
        [JsonProperty("security_class")]
        public string SecurityClass { get; set; }

        /// <summary>
        /// Gets or sets the system security status
        /// </summary>
        [JsonProperty("security_status")]
        public float SecurityStatus { get; set; }

        /// <summary>
        /// Gets or sets the system's star id
        /// </summary>
        [JsonProperty("star_id")]
        public int StarID { get; set; }

        /// <summary>
        /// Gets or sets the stargates within the system
        /// </summary>
        [JsonProperty("stargates")]
        public List<int> Stargates { get; set; } = new List<int>();

        /// <summary>
        /// Gets or sets the stations within the system
        /// </summary>
        [JsonProperty("stations")]
        public List<int> Stations { get; set; } = new List<int>();
    }
}
