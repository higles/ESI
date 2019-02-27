using ESI.Classes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ESI.Models
{
    /// <summary>
    /// Planet class
    /// </summary>
    public class Planet
    {
        /// <summary>
        /// Gets or sets the planet id
        /// </summary>
        [JsonProperty("planet_id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the asteroid belts associated with this planet
        /// </summary>
        [JsonProperty("asteroid_belts")]
        public List<int> AsteroidBelts { get; set; }

        /// <summary>
        /// Gets or sets the moons associated with this planet
        /// </summary>
        [JsonProperty("moons")]
        public List<int> Moons { get; set; }

        /// <summary>
        /// Gets or sets the planet name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the stellar position of this planet
        /// </summary>
        [JsonProperty("position")]
        public StellarPosition Position { get; set; } = new StellarPosition();

        /// <summary>
        /// Gets or sets the id of the solar system this planet is in
        /// </summary>
        [JsonProperty("system_id")]
        public int SystemID { get; set; }

        /// <summary>
        /// Gets or sets the type ID
        /// </summary>
        [JsonProperty("type_id")]
        public int TypeID { get; set; }
    }
}
