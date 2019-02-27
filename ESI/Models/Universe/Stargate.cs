using ESI.Classes;
using Newtonsoft.Json;

namespace ESI.Models
{
    /// <summary>
    /// Stargate class
    /// </summary>
    public class Stargate
    {
        /// <summary>
        /// Gets or sets the stargate ID
        /// </summary>
        [JsonProperty("stargate_id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the destination of this stargate
        /// </summary>
        [JsonProperty("destination")]
        public GateDestination Destination { get; set; } = new GateDestination();

        /// <summary>
        /// Gets or sets the stargate name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the stellar position of this stargate
        /// </summary>
        [JsonProperty("position")]
        public StellarPosition Position { get; set; } = new StellarPosition();

        /// <summary>
        /// Gets or sets the ID of the solar system this stargate is in
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
