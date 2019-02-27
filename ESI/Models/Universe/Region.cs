using Newtonsoft.Json;
using System.Collections.Generic;

namespace ESI.Models
{
    /// <summary>
    /// Region class
    /// </summary>
    public class Region
    {
        /// <summary>
        /// Gets or sets the region ID
        /// </summary>
        [JsonProperty("region_id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the constellations within this region
        /// </summary>
        [JsonProperty("constellations")]
        public List<int> Constellations { get; set; } = new List<int>();

        /// <summary>
        /// Gets or sets the region description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the region name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
