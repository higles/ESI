using ESI.Classes;
using Newtonsoft.Json;

namespace ESI.Models
{
    /// <summary>
    /// Structure class
    /// </summary>
    public class Structure
    {
        /// <summary>
        /// Gets or sets the full name of the structure
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ID of the corporation who owns this particular structure
        /// </summary>
        [JsonProperty("owner_id")]
        public int OwnerID { get; set; }

        /// <summary>
        /// Gets or sets the stellar position of the structure
        /// </summary>
        [JsonProperty("position")]
        public StellarPosition Position { get; set; } = new StellarPosition();

        /// <summary>
        /// Gets or sets the solar system ID
        /// </summary>
        [JsonProperty("solar_system_id")]
        public int SolarSystemID { get; set; }

        /// <summary>
        /// Gets or sets the type ID
        /// </summary>
        [JsonProperty("type_id")]
        public int TypeID { get; set; }
    }
}
