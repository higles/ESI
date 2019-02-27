using ESI.Classes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ESI.Models
{
    /// <summary>
    /// Constellation class
    /// </summary>
    public class Constellation
    {
        /// <summary>
        /// Gets or sets the constellation id
        /// </summary>
        [JsonProperty("constellation_id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the constellation name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the stellar position of this constellation
        /// </summary>
        [JsonProperty("position")]
        public StellarPosition Position { get; set; } = new StellarPosition();

        /// <summary>
        /// Gets or sets the ID of the region this constellation is in
        /// </summary>
        [JsonProperty("region_id")]
        public int RegionID { get; set; }

        /// <summary>
        /// Gets or sets the systems within this constellation
        /// </summary>
        [JsonProperty("systems")]
        public List<int> Systems { get; set; }
    }
}
