using Newtonsoft.Json;

namespace ESI.Models
{
    /// <summary>
    /// Bloodline class
    /// </summary>
    public class Bloodline
    {
        /// <summary>
        /// Gets or sets the bloodline ID
        /// </summary>
        [JsonProperty("bloodline_id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the base charisma for this bloodline
        /// </summary>
        [JsonProperty("charisma")]
        public int Charisma { get; set; }

        /// <summary>
        /// Gets or sets the corporation ID for this bloodline
        /// </summary>
        [JsonProperty("corporation_id")]
        public int CorporationID { get; set; }

        /// <summary>
        /// Gets or sets the bloodline description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the base intelligence for this bloodline
        /// </summary>
        [JsonProperty("intelligence")]
        public int Intelligence { get; set; }

        /// <summary>
        /// Gets or sets the base memory for this bloodline
        /// </summary>
        [JsonProperty("memory")]
        public int Memory { get; set; }

        /// <summary>
        /// Gets or sets the bloodline name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the base perception for this bloodline
        /// </summary>
        [JsonProperty("perception")]
        public int Perception { get; set; }

        /// <summary>
        /// Gets or sets the race for this bloodline
        /// </summary>
        [JsonProperty("race_id")]
        public int RaceID { get; set; }

        /// <summary>
        /// Gets or sets the ship type for this bloodline
        /// </summary>
        [JsonProperty("ship_type_id")]
        public int ShipTypeID { get; set; }

        /// <summary>
        /// Gets or sets the base willpower for this bloodline
        /// </summary>
        [JsonProperty("willpower")]
        public int Willpower { get; set; }
    }
}
