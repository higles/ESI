using Newtonsoft.Json;

namespace ESI.Models
{
    /// <summary>
    /// Faction class
    /// </summary>
    public class Faction
    {
        /// <summary>
        /// Gets or sets the faction ID
        /// </summary>
        [JsonProperty("faction_id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the corporation ID
        /// </summary>
        [JsonProperty("corporation_id")]
        public int CorporationID { get; set; }
        
        /// <summary>
        /// Gets or sets the faction description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this faction is unique
        /// </summary>
        [JsonProperty("is_unique")]
        public bool IsUnique { get; set; }

        /// <summary>
        /// Gets or sets the militia corporation ID
        /// </summary>
        [JsonProperty("militia_corporation_id")]
        public int MilitiaCorporationID { get; set; }

        /// <summary>
        /// Gets or sets the faction name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the faction size factor
        /// </summary>
        [JsonProperty("size_factor")]
        public float SizeFactor { get; set; }

        /// <summary>
        /// Gets or sets the solar system id
        /// </summary>
        [JsonProperty("solor_system_id")]
        public int SolorSystemID { get; set; }

        /// <summary>
        /// Gets or sets the faction's station count
        /// </summary>
        [JsonProperty("station_count")]
        public int StationCount { get; set; }

        /// <summary>
        /// Gets or sets the station system count
        /// </summary>
        [JsonProperty("station_system_count")]
        public int StationSystemCount { get; set; }
    }
}
