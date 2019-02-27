using Newtonsoft.Json;

namespace ESI.Classes
{
    /// <summary>
    /// Effect class
    /// </summary>
    public class Effect
    {
        /// <summary>
        /// Gets or sets the effect id
        /// </summary>
        [JsonProperty("effect_id")]
        public int EffectID { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is a default effect
        /// </summary>
        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }
    }
}
