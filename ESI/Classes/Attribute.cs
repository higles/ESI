using Newtonsoft.Json;

namespace ESI.Classes
{
    /// <summary>
    /// Attribute class
    /// </summary>
    public class Attribute
    {
        /// <summary>
        /// Gets or sets the attribute id
        /// </summary>
        [JsonProperty("attribute_id")]
        public int AttributeID { get; set; }

        /// <summary>
        /// Gets or sets the attribute value
        /// </summary>
        [JsonProperty("value")]
        public float Value { get; set; }
    }
}
