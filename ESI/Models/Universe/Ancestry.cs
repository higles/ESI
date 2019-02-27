using Newtonsoft.Json;

namespace ESI.Models
{
    /// <summary>
    /// Ancestry class
    /// </summary>
    public class Ancestry
    {
        /// <summary>
        /// Gets or sets the ancestry ID
        /// </summary>
        [JsonProperty("id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the bloodline associated with this ancestry
        /// </summary>
        [JsonProperty("bloodline_id")]
        public int BloodlineID { get; set; }

        /// <summary>
        /// Gets or sets the ancestry description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the icon ID
        /// </summary>
        [JsonProperty("icon_id")]
        public int IconID { get; set; }

        /// <summary>
        /// Gets or sets the ancestry name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ancestry short description
        /// </summary>
        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }
    }
}
