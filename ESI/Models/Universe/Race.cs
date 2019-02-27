using Newtonsoft.Json;

namespace ESI.Models
{
    /// <summary>
    /// Race class
    /// </summary>
    public class Race
    {
        /// <summary>
        /// Gets or sets the race ID
        /// </summary>
        [JsonProperty("race_id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the alliance generally associated with this race
        /// </summary>
        [JsonProperty("alliance_id")]
        public int AllianceID { get; set; }

        /// <summary>
        /// Gets or sets the description of this race
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the name of this race
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
