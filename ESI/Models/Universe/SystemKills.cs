using Newtonsoft.Json;

namespace ESI.Models
{
    /// <summary>
    /// System Kills class
    /// </summary>
    public class SystemKills
    {
        /// <summary>
        /// Gets or sets the number of system NPC kills
        /// </summary>
        [JsonProperty("npc_kills")]
        public int NPCKills { get; set; }

        /// <summary>
        /// Gets or sets the number of system pod kills
        /// </summary>
        [JsonProperty("pod_kills")]
        public int PodKills { get; set; }

        /// <summary>
        /// Gets or sets the number of system ship kills
        /// </summary>
        [JsonProperty("ship_kills")]
        public int ShipKills { get; set; }

        /// <summary>
        /// Gets or sets the system ID
        /// </summary>
        [JsonProperty("system_id")]
        public int SystemID { get; set; }
    }
}
