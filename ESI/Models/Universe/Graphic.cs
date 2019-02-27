using Newtonsoft.Json;

namespace ESI.Models
{
    /// <summary>
    /// Graphic class
    /// </summary>
    public class Graphic
    {
        /// <summary>
        /// Gets or sets the graphic ID
        /// </summary>
        [JsonProperty("graphic_id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the collision file
        /// </summary>
        [JsonProperty("collision_file")]
        public string CollisionFile { get; set; }

        /// <summary>
        /// Gets or sets the graphic file
        /// </summary>
        [JsonProperty("graphic_file")]
        public string GraphicFile { get; set; }

        /// <summary>
        /// Gets or sets the folder for this graphic's icon
        /// </summary>
        [JsonProperty("icon_folder")]
        public string IconFolder { get; set; }

        /// <summary>
        /// Gets or sets the SoF DNA
        /// </summary>
        [JsonProperty("sof_dna")]
        public string SofDNA { get; set; }

        /// <summary>
        /// Gets or sets the SoF faction name
        /// </summary>
        [JsonProperty("sof_fation_name")]
        public string SofFactionName { get; set; }

        /// <summary>
        /// Gets or sets the SoF hull name
        /// </summary>
        [JsonProperty("sof_hull_name")]
        public string SofHullName { get; set; }

        /// <summary>
        /// Gets or sets the SoF race name
        /// </summary>
        [JsonProperty("sof_race_name")]
        public string SofRaceName { get; set; }
    }
}
