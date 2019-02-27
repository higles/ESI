using Newtonsoft.Json;

namespace ESI.Classes
{
    /// <summary>
    /// Stellar Position of a celestial object
    /// </summary>
    public class StellarPosition
    {
        /// <summary>
        /// Gets or sets the x position
        /// </summary>
        [JsonProperty("x")]
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the y position
        /// </summary>
        [JsonProperty("y")]
        public double Y { get; set; }

        /// <summary>
        /// Gets or sets the z position
        /// </summary>
        [JsonProperty("z")]
        public double Z { get; set; }
    }
}
