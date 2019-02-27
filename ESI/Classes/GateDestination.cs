using Newtonsoft.Json;

namespace ESI.Classes
{
    /// <summary>
    /// Destination for a stargate
    /// </summary>
    public class GateDestination
    {
        /// <summary>
        /// Gets or sets the stargate being connected to
        /// </summary>
        [JsonProperty("stargate_id")]
        public int StargateID { get; set; }

        /// <summary>
        /// Gets or sets the system being connected to
        /// </summary>
        [JsonProperty("system_id")]
        public int SystemID { get; set; }
    }
}
